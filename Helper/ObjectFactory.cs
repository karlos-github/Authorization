using System.Linq.Expressions;
using System.Reflection;

namespace AuthorizationStudio9.Helper
{
	public static class ObjectFactory<TKey, TType>
	{
		static readonly Dictionary<TKey, Func<object[], TType>> _registeredTypes = new Dictionary<TKey, Func<object[], TType>>();
		static object _locker = new object();

		public static void Register(TKey key, params Type[] ctorParameters)
		{
			ConstructorInfo ci = typeof(TType).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, CallingConventions.HasThis, ctorParameters, new ParameterModifier[] { });
			if (ci == null)
				throw new InvalidOperationException(string.Format("Constructor for type '{0}' was not found.", typeof(TType)));

			Func<object[], TType> ctor;
			lock (_locker)
			{
				if (!_registeredTypes.TryGetValue(key, out ctor))
				{
					var pExp = Expression.Parameter(typeof(object[]), "arguments");
					var ctorParams = ci.GetParameters();

					var argExpressions = new Expression[ctorParams.Length];
					for (var i = 0; i < ctorParameters.Length; i++)
					{
						var indexedAcccess = Expression.ArrayIndex(pExp, Expression.Constant(i));
						if (!ctorParameters[i].IsClass && !ctorParameters[i].IsInterface)
						{
							var localVariable = Expression.Variable(ctorParameters[i], "localVariable");
							var block = Expression.Block(new[] { localVariable },
									Expression.IfThenElse(Expression.Equal(indexedAcccess, Expression.Constant(null)),
										Expression.Assign(localVariable, Expression.Default(ctorParameters[i])),
										Expression.Assign(localVariable, Expression.Convert(indexedAcccess, ctorParameters[i]))
									),
									localVariable
								);

							argExpressions[i] = block;

						}
						else
							argExpressions[i] = Expression.Convert(indexedAcccess, ctorParameters[i]);
					}
					var newExpr = Expression.New(ci, argExpressions);

					_registeredTypes.Add(key, Expression.Lambda(newExpr, new[] { pExp }).Compile() as Func<object[], TType>);
				}
			}
		}

		public static TType Create(TKey key, params object[] args)
		{
			if (_registeredTypes.TryGetValue(key, out Func<object[], TType> obj))
			{
				return (TType)obj(args);
			}

			throw new ArgumentException("No type registered for this key.");
		}
	}
}
