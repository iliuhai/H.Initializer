
namespace Test.Initializer
{
    public class BaseResultModel
    {
        public BaseResultModel(int? code = null, string message = null, object data = null)
        {
            this.code = code;
            this.message = message;
            this.data = data;
        }

        public int? code { get; set; }

        public string message { get; set; }

        public object data { get; set; }
    }
}
