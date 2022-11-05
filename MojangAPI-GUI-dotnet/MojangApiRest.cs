using RestSharp;
using System.ComponentModel;
using System.Text.Json;

namespace MojangAPI_GUI_dotnet
{
    public class MojangApiRest
    {
        string? client_id;
        string? device_code;
        string? msaccount_token;
        string? xboxlive_token;
        string? xsts_token;
        string? xsts_userhash;
        string? mcservices_access_token;
        string? mc_uuid;

        public MojangApiRest(string client_id)
        {
            this.client_id = client_id;
        }

        public string? MSAuthDevice()
        {
            var client = new RestClient("https://login.microsoftonline.com/consumers/oauth2/v2.0/devicecode?mkt=ja-JP");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddStringBody("client_id=" + client_id + "&scope=xboxlive.signin", "application/x-www-form-urlencoded");
            string? responseJson = client.Execute(request).Content;
            MSAuthDeviceResponse? response = JsonSerializer.Deserialize<MSAuthDeviceResponse>(responseJson);
            device_code = response.device_code;
            return response.message;
        }

        class MSAuthDeviceResponse
        {
            //200: OK
            public string? user_code { get; set; }
            public string? device_code { get; set; }
            public string? verification_uri { get; set; }
            public int? expires_in { get; set; }
            public int? interval { get; set; }
            public string? message { get; set; }
        }

        public string? MSAuthToken()
        {
            var client = new RestClient("https://login.microsoftonline.com/consumers/oauth2/v2.0/token");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddStringBody("grant_type=urn:ietf:params:oauth:grant-type:device_code&client_id=" + client_id + "&device_code=" + device_code,
                "application/x-www-form-urlencoded");
            string? responceJson = client.Execute(request).Content;
            MSAuthTokenResponce? responce = JsonSerializer.Deserialize<MSAuthTokenResponce>(responceJson);
            if (responce.access_token == null)
            {
                return responce.error_description;
            }
            msaccount_token = responce.access_token;
            return responceJson;
        }

        class MSAuthTokenResponce
        {
            //200: OK
            public string? token_type { get; set; }
            public string? scope { get; set; }
            public int? expires_in { get; set; }
            public int? ext_expires_in { get; set; }
            public string? access_token { get; set; }

            //400: Bad Request
            public string? error { get; set; }
            public string? error_description { get; set; }
            public int[]? error_codes { get; set; }
            public string? timestamp { get; set; }
            public string? trace_id { get; set; }
            public string? correlation_id { get; set; }
            public string? error_uri { get; set; }
        }

        public string? XboxLiveToken()
        {
            var client = new RestClient("https://user.auth.xboxlive.com/user/authenticate");
            var request = new RestRequest();
            request.Method = Method.Post;
            var jsonBody = "{\"Properties\": {\"AuthMethod\": \"RPS\",\"SiteName\": \"user.auth.xboxlive.com\",\"RpsTicket\": \"d=" + msaccount_token + "\"},\"RelyingParty\": \"http://auth.xboxlive.com\",\"TokenType\": \"JWT\"}";
            request.AddStringBody(jsonBody, DataFormat.Json);
            RestResponse restResponse = client.Execute(request);
            string? responceJson = restResponse.Content;
            if (responceJson == "")
            {
                return ((int)restResponse.StatusCode) + ": "  + restResponse.StatusCode.ToString();
            }
            XboxLiveTokenResponce? responce = JsonSerializer.Deserialize<XboxLiveTokenResponce>(responceJson);
            xboxlive_token = responce.Token;
            
            return responceJson;
        }

        class XboxLiveTokenResponce
        {
            //200: OK
            public string? IssueInstant { get; set; }
            public string? NotAfter { get; set; }
            public string? Token { get; set; }
            public displayClaims? DisplayClaims { get; set; }

            public class displayClaims
            {
                public Xui[]? xui { get; set; }

                public class Xui
                {
                    public string? uhs { get; set; }
                }
            }

            //XSTS: 401 Error
            public string? Identity { get; set; }
            public int? XErr { get; set; }
            public string? Message { get; set; }
            public string? Redirect { get; set; }
        }

        public string? XboxLiveXSTSToken()
        {
            var client = new RestClient("https://xsts.auth.xboxlive.com/xsts/authorize");
            var request = new RestRequest();
            request.Method = Method.Post;
            var jsonBody = "{\"Properties\": {\"SandboxId\": \"RETAIL\",\"UserTokens\": [\"" + xboxlive_token + "\"]},\"RelyingParty\": \"rp://api.minecraftservices.com/\",\"TokenType\": \"JWT\"}";
            request.AddStringBody(jsonBody, DataFormat.Json);
            RestResponse restResponse = client.Execute(request);
            string? responceJson = restResponse.Content;
            XboxLiveTokenResponce? responce = JsonSerializer.Deserialize<XboxLiveTokenResponce>(responceJson);
            if (responce.Token == null)
            {
                return responce.XErr + "\r\n" + responce.Message + "\r\n" + responce.Redirect;
            }
            xsts_token = responce.Token;
            xsts_userhash = responce.DisplayClaims.xui[0].uhs;

            return (int)restResponse.StatusCode + ": " + restResponse.StatusCode.ToString() + "\r\n" + responceJson;
        }

        public string? MinecraftServicesAccessToken()
        {
            var client = new RestClient("https://api.minecraftservices.com/authentication/login_with_xbox");
            var request = new RestRequest();
            request.Method = Method.Post;
            var jsonBody = "{\"identityToken\": \"XBL3.0 x=" + xsts_userhash + ";" + xsts_token + "\"}";
            request.AddStringBody(jsonBody, DataFormat.Json);
            RestResponse restResponse = client.Execute(request);
            if ((int)restResponse.StatusCode != 200)
            {
                return ((int)restResponse.StatusCode) + ": " + restResponse.StatusCode.ToString();
            }
            string? responceJson = restResponse.Content;
            var responce = JsonSerializer.Deserialize<MinecraftServicesAccessTokenResponse>(responceJson);
            mcservices_access_token = responce.access_token;

            return responceJson;
        }

        class MinecraftServicesAccessTokenResponse
        {
            public string? username { get; set; }
            public string[]? roles { get; set; }
            public Metadata? metadata { get; set; }
            public string? access_token { get; set; }
            public int? expires_in { get; set; }
            public string? token_type { get; set; }

            public class Metadata { }
        }

        public string? MinecraftProfile()
        {
            var client = new RestClient("https://api.minecraftservices.com/minecraft/profile");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", "Bearer " + mcservices_access_token);
            RestResponse restResponse = client.Execute(request);
            string? responceJson = restResponse.Content;
            var response = JsonSerializer.Deserialize<MinecraftProfileResponse>(responceJson);
            mc_uuid = response.id;

            return responceJson;
        }

        class MinecraftProfileResponse
        {
            public string? id { get; set; }
            public string? name { get; set; }
            public Skins[]? skins { get; set; }
            public Capes[]? capes { get; set; }

            public class Skins
            {
                public string? id { set; get; }
                public string? state { set; get; }
                public string? url { set; get; }
                public string? variant { set; get; }
            }

            public class Capes
            {
                public string? id { set; get; }
                public string? state { set; get; }
                public string? url { set; get; }
                public string? alias { set; get; }
            }
        }
        
        public string? MinecraftNameChangeInfo()
        {
            var client = new RestClient("https://api.minecraftservices.com/minecraft/profile/namechange");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", "Bearer " + mcservices_access_token);
            RestResponse restResponse = client.Execute(request);
            string? responceJson = restResponse.Content;
            var response = JsonSerializer.Deserialize<MinecraftNameChangeInfoResponse>(responceJson);

            return responceJson;
        }

        class MinecraftNameChangeInfoResponse
        {
            public string? changeAt { set; get; }
            public string? createdAt { set; get; }
            public bool? nameChangeAllowed { set; get; }
        }
    }
}
