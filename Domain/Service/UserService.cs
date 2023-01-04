using Domain.Helper;
namespace Domain.Service;


public interface IUserService
{
	//Task<string> Login(PasargadRequestDto request, List<KeyValuePair<string, string>> requestBody);
}

public class UserService : IUserService
{
	//private readonly NeoBankContext Context;
	private IHttpProvider HttpProvider;

	public UserService(IHttpProvider httpProvider) //NeoBankContext context,
	{
		//Context = context;
		HttpProvider = httpProvider;
	}


}
