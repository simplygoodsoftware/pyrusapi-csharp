using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Pyrus.ApiClient.Helpers
{
	public class NoDisposeStreamWrapper : Stream
	{
		private readonly Stream _stream;

		public NoDisposeStreamWrapper(Stream stream)
		{
			_stream = stream;
		}

		public override bool CanRead => _stream.CanRead;

		public override bool CanSeek => _stream.CanSeek;

		public override bool CanWrite => false;

		public override long Length => _stream.Length;

		public override long Position { get => _stream.Position; set => _stream.Position = value; }

		public override void Flush() => _stream.Flush();

		public override int Read(byte[] buffer, int offset, int count) => _stream.Read(buffer, offset, count);

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
			_stream.ReadAsync(buffer, offset, count, cancellationToken);

		public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);

		public override Task FlushAsync(CancellationToken cancellationToken) => _stream.FlushAsync(cancellationToken);

		public override void SetLength(long value) => throw new InvalidOperationException();

		public override void Write(byte[] buffer, int offset, int count) => throw new InvalidOperationException();
	}
}
