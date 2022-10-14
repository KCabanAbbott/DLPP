namespace datamgmt.logger
{
	// DbLoggerOptions.cs
	public class DbLoggerOptions
	{
		public string ConnectionString { get; init; }

		public string[] LogFields { get; init; }

		public string LogTable { get; init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DbLoggerOptions()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
		}
	}
}