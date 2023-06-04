using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity
{
	public class Generic<T, U>
	{
		public int StatusCode { get; set; }
		public T SuccessResult { get; set; }
		public string FailureMessage { get; set; }
		public U FailureResult { get; set; }

	}
}
