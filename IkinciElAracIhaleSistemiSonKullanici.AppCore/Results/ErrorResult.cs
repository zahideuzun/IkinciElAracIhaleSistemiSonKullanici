﻿using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results.Bases;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.Results
{
	public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false, "")
        {
        }
    }
}
