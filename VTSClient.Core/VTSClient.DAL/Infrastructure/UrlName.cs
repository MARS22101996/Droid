namespace VTSClient.DAL.Infrastructure
{
    public class UrlName
    {
        public static string GetApiUrl()
        {
            const string hostUrl = "http://localhost:5002";

            const string vacationUrl = hostUrl + "/vts/workflow";

            return vacationUrl;
        }

		public static string GetAccountUrl()
		{
			const string hostUrl = "http://localhost:5002";

			const string vacationUrl = hostUrl + "/vts/signin";

			return vacationUrl;
		}
	}
}
