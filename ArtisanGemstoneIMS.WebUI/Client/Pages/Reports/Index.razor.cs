namespace ArtisanGemstoneIMS.WebUI.Client.Pages.Reports;

public partial class Index
{
    private string ReportToDisplay = "low inventory";

    private void ShowLowInventory()
    {
        ReportToDisplay = "low inventory";
    }

    private void ShowInventoryHistory()
    {
        ReportToDisplay = "inventory history";
    }
}