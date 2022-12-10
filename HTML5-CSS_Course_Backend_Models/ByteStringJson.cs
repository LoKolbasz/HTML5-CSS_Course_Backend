using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HTML5_CSS_Course_Backend_Models
{
    public class ByteStringJson : JsonConverter<byte[]>
    {
        public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Encoding.UTF8.GetBytes(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(Encoding.UTF8.GetString(value));
        }
    }
}