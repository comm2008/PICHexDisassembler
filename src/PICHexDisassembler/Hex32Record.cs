﻿using PICHexDisassembler.Instructions;

namespace PICHexDisassembler
{
    public class Hex32Record
    {
        public Hex32Record(byte byteCount, int address, byte recordType, byte[][] dataBytes, byte checksum)
        {
            ByteCount = byteCount;
            Address = address;
            RecordType = recordType;
            DataBytes = dataBytes;
            Checksum = checksum;

            var wordsCount = byteCount / 2;
            Mnemonics = new Instruction[wordsCount];
            for (int i = 0; i < wordsCount; i++)
            {
                Mnemonics[i] = Mnemonic.Parse(dataBytes[i]);
            }
        }

        public byte ByteCount { get; }
        public int Address { get; }
        public byte RecordType { get; }
        public byte[][] DataBytes { get; }
        public byte Checksum { get; }

        public Instruction[] Mnemonics { get; }
    }
}
