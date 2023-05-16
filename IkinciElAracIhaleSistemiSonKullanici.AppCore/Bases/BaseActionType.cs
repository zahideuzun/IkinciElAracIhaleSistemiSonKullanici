using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.AppCore.Bases
{
	public static class BaseActionType
	{
		public static IActionResult ReturnResponse(object data)
		{
			if (data == null)
			{
				return new BadRequestResult();
			}
			return new OkObjectResult(data);
		}
	}

}
