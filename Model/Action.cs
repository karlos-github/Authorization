using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorizationStudio9.Model
{
	[Table("Action")]
	public class Action
	{
		[Key]
		public int ActionId { get; set; }
		public string ActionName { get; set; } 
		public string Note { get; set; } 

        public Action()
        {
            
        }

        public Action(int actionId, string actionName, string note)
		{
			ActionId = actionId;
			ActionName = actionName;
			Note = note;
		}
	}
}
