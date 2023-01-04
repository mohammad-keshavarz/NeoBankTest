using Domain.Helper;
using Domain.Service;
using Domain.Models;
using Moq;

namespace Test;

public interface INeoBankTest
{

}


[TestFixture]
public class NeoBankUserTest : INeoBankTest
{

	UserService _userService;
	IHttpProvider _httpProvider;
	NeoBankContext _context;


	[OneTimeSetUp]
	public void Setup()
	{
		_context = Mock.Of<NeoBankContext>();
		_httpProvider = Mock.Of<HttpProvider>();
		_userService = new UserService(_httpProvider);
	}

	[Test]
	public async Task Test1()
	{
		var request = new PasargadRequestDto();
		var requestBody = new List<KeyValuePair<string, string>>
		{
				new KeyValuePair<string, string>("nationalCode","0063429764"),
				new KeyValuePair<string, string>("captcha", ""),
		};

		var response = _userService.Login(request, requestBody);

		Assert.Pass();
	}
}