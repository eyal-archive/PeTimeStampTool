namespace PeTimeStampTool.Core
{
	using System.IO;
	using System.Runtime.InteropServices;

	using PeTimeStampTool.Core.Native;

	public sealed class FileHeaderReader
	{
		public FileHeaderInfo GetFileHeader(string path)
		{
			bool exist = File.Exists(path);

			if (!exist)
			{
				throw new FileNotFoundException(string.Format("The PE file at '{0}' does not exist.", path));
			}

			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryReader reader = new BinaryReader(stream);

				IMAGE_DOS_HEADER dosHeader = FromBinaryReader<IMAGE_DOS_HEADER>(reader);

				reader.BaseStream.Position = stream.Seek(dosHeader.e_lfanew, SeekOrigin.Begin) + 4;

				IMAGE_FILE_HEADER fileHeader = FromBinaryReader<IMAGE_FILE_HEADER>(reader);

				return new FileHeaderInfo(fileHeader);
			}
		}

		private static T FromBinaryReader<T>(BinaryReader reader) where T : struct
		{
			byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

			GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
			var theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
			handle.Free();

			return theStructure;
		}
	}
}