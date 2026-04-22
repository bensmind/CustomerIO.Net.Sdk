using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Form;

public class FormSubmitRequest
{
    /// <summary>
    /// Form field data. Must contain at least one of "id" or "email" to identify the respondent.
    /// All values must be strings. Additional keys represent form fields mapped to person attributes.
    /// Customer.io reserves the keys: form_id, form_name, form_type, form_url, form_url_param.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, string> Data { get; set; } = null!;
}
