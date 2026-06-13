namespace CleanTeeth.API.Utilities
{
    public static class HttpContextExtentions
    {
        public static void InsertPaginationsInformationInHeader(this HttpContext httpContext, int totalAmountOfRecords)
        {
            httpContext.Response.Headers.Append("total-amount-of-records", totalAmountOfRecords.ToString());
        }
    }
}
