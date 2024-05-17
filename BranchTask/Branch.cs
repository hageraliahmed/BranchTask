using System.ComponentModel.DataAnnotations.Schema;

namespace BranchTask
{
	public class Branch
	{
        public int BranchId { get; set; }    
		public int CustomNo { get; set; }


		[Column(TypeName = "varchar(100)")]
		public string ?ArabicName { get; set; } 


		[Column(TypeName = "varchar(1000)")]
		public string ?ArabicDescription { get; set; } 


		[Column(TypeName = "varchar(100)")]
		public string ?EnglishName { get; set; }


		[Column(TypeName = "varchar(1000)")]
		public string ?EnglishDescription { get; set; }


		[Column(TypeName = "varchar(1000)")]
		public string? Note { get; set; } 


		[Column(TypeName = "varchar(100)")]
		public string? Address { get; set; } 


    }
}
