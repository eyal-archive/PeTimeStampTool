namespace PeTimeStampTool.Core.Native
{
	using System.Runtime.InteropServices;

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global
	internal struct IMAGE_FILE_HEADER
// ReSharper restore InconsistentNaming
	{
		public ushort Machine;

		public ushort NumberOfSections;

		public uint TimeDateStamp;

		public uint PointerToSymbolTable;

		public uint NumberOfSymbols;

		public ushort SizeOfOptionalHeader;

		public ushort Characteristics;
	}
// ReSharper restore FieldCanBeMadeReadOnly.Global
}