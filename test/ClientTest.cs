namespace Belin.FreeMobile;

/// <summary>
/// Tests the features of the <see cref="Client"/> class.
/// </summary>
[TestClass]
public sealed class ClientTest {

	[TestMethod("It should throw a `HttpRequestException` if a network error occurred")]
	public async Task NetworkError() {
		var client = new Client("anonymous", "secret", "http://localhost:10000");
		await ThrowsAsync<HttpRequestException>(() => client.SendMessage("Hello World!"));
	}

	[TestMethod("It should throw a `HttpRequestException` if the credentials are invalid")]
	public async Task InvalidCredentials() {
		var client = new Client("anonymous", "secret");
		await ThrowsAsync<HttpRequestException>(() => client.SendMessage("Hello World!"));
	}

	[TestMethod("It should send SMS messages if the credentials are valid")]
	public async Task ValidCredentials() {
		var client = new Client(Environment.GetEnvironmentVariable("FREEMOBILE_ACCOUNT")!, Environment.GetEnvironmentVariable("FREEMOBILE_API_KEY")!);
		await client.SendMessage("Hello Cédric, from .NET!");
	}
}
