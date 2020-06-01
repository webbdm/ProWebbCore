using System;
using System.Collections.Generic;
using System.Text;

namespace ProWebbCore.Infrastructure.Communication.Files
{
	public class AddFileResponse
	{
		public IList<string> PreSignedUrl { get; set; }
	}
}
