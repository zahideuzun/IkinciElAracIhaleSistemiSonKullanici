namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.Results.Bases
{
	public class Result
    {
        public bool IsSuccessful { get; }
        public string Message { get; set; }

        public Result(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
