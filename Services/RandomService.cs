namespace ProvaPub.Services
{
	public class RandomService
	{
		int seed;

		public RandomService()
		{
			seed = Guid.NewGuid().GetHashCode();
		}
		public int GetRandom()
		{
			Random Rand = new Random();
			int retorno = 0;
			retorno = Rand.Next(0,100);
			return retorno;
		}

	}
}
