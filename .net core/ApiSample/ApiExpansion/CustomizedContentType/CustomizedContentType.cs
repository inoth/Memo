using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace ApiExpansion.CustomizedContentType
{
    public class CustomizedContentType : TextOutputFormatter
    {
        public CustomizedContentType()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/inoth"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            // 自定义转换格式
            await context.HttpContext.Response.WriteAsync("");
        }
    }
}