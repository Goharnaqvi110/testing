# Configuration

Credentials are intentionally not included in the repository. Configure these
environment variables before running the application:

| Environment variable | Purpose |
| --- | --- |
| `ConnectionStrings__DefaultConnection` | SQL Server connection string |
| `Twilio__AccountSid` | Twilio account identifier |
| `Twilio__AuthToken` | Twilio authentication token |
| `Twilio__FromPhoneNumber` | Twilio sender phone number |
| `Smtp__Host` | SMTP server host |
| `Smtp__Port` | SMTP server port |
| `Smtp__FromAddress` | Sender email address |
| `Smtp__UserName` | SMTP account username |
| `Smtp__Password` | SMTP account password |
| `sendpk__baseUrl` | SendPK API base URL |
| `sendpk__apikey` | SendPK API key |

For local development, use .NET User Secrets or environment variables. Do not
commit credentials to source control. Rotate any credentials that were
previously stored in the application settings or payment controller.

The Bank Alfalah payment handshake is currently disabled and is not included;
configure and implement it separately using credentials provided through a
secure configuration provider.
