namespace RAM.RAMPAGE.Runtime.Validation
{
	public interface IValidatable
	{
		void OnValidate();
		string name { get; }
	}
}