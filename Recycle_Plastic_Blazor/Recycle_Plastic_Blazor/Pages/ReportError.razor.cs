using Microsoft.AspNetCore.Components;

namespace Recycle_Plastic_Blazor.Pages
{
	public partial class ReportError
	{
		[Parameter]
		public int ErrorCode { get; set; }
		[Parameter]
		public string ErrorDescription { get; set; }
	}
}
