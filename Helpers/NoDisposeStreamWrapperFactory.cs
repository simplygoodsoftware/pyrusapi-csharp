using System.IO;

namespace Pyrus.ApiClient.Helpers
{
	public class NoDisposeStreamWrapperFactory
	{
		private readonly Stream _stream;
		private readonly long _originalPosition;

		public NoDisposeStreamWrapperFactory(Stream source)
		{
			_stream = source.CanSeek ? source : CreateMemoryStream(source);
			_originalPosition = _stream.Position;
		}

		private Stream CreateMemoryStream(Stream source)
		{
			var result = new MemoryStream();
			source.CopyTo(result);
			result.Seek(0, SeekOrigin.Begin);
			return result;
		}

		public Stream Create()
		{
			_stream.Position = _originalPosition;
			return new NoDisposeStreamWrapper(_stream);
		}
	}
}
