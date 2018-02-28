using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateCCG.Helpers
{
	public static class RandomImageGenerator
	{
		public static string GetRandomImageUrl(int width = 600, int height = 600)
		{
			var randomImageUrl = string.Format("http://loremflickr.com/{1}/{2}/nature?filename={0}.jpg",
				Guid.NewGuid().ToString("N"), width, height);
			return randomImageUrl;
		}
	}
}
