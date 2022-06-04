# WhatsApp API in Dotnet C#
Using this API, one can send and respond to WhatsApp messages programmatically.

### Steps to create WhatsApp API
1. Create Developer account at meta
https://developers.facebook.com/async/registration/

2. Integrate with WhatsApp.
You will receive a test WhatsApp number to send info to upto 5 contacts.

3. Use temporary(24h) AccessTokens to send whats app messages using Postman or API

4. Sending messages using templates is straight forward but sending direct text messages requires a message from the user.

5. Setting up webhooks, follow the steps here-
https://developers.facebook.com/docs/graph-api/webhooks/getting-started#configure-webhooks-product

### Project setup

1. Clone the project `git clone https://github.com/NeetishRaj/WhatsAppApiDotnet.git`
2. Make sure the dotnet CLI and dotnet5.0 packages are installed.
3. Create a file in root called `appsettings.Development.json`. Copy the contents from `appsettings.json` and fill in the details for `WhatsApp` section from your developer console.
4. In the root folder run the following
```
dotnet restore
dotnet build
dotnet run
```
5. Now test the endpoints in Postman, for API reference use Swagger endpoint `https://localhost:5001/swagger`


### Webhook setup
In order to test the Webhook feature, this API needs ot be hosted somewhere so that we can have callback URL to be configured in developer's console. Following these insrtuctions https://developers.facebook.com/docs/graph-api/webhooks/getting-started#configure-webhooks-product


**Note:** The details are even well documented in their Postman collection page here https://www.postman.com/meta/workspace/whatsapp-business-platform/folder/13382743-08213e00-c6d0-48a2-8be8-62247b8d29bd

