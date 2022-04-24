namespace Abstractions
{
    public interface ITask : IIconHolder
    {
    	public string TaskName { get; }
    	public float TimeLeft { get; }
    	public float ProductionTime { get; }
    }
}