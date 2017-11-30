﻿using System;
using System.IO;

namespace KenticoCloud.ContentManagement.Models.Assets
{
    /// <summary>
    /// Wraps the information about file content source.
    /// </summary>
    public class FileContentSource
    {
        private byte[] Data { get; set; }

        private string FilePath { get; set; }

        private Stream Stream { get; set; }

        internal bool CreatesNewStream { get; private set; }

        /// <summary>
        /// Type of the file content. e.g. "image/jpeg"
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; set; }

        private FileContentSource() { }

        /// <summary>
        /// Gets an open stream for the file data
        /// </summary>
        public Stream OpenReadStream()
        {
            if (Stream != null)
            {
                return Stream;
            }

            if (Data != null)
            {
                return new MemoryStream(Data);
            }

            if (FilePath != null)
            {
                return File.OpenRead(FilePath);
            }

            throw new InvalidOperationException("File content source does not have any source set.");
        }

        public FileContentSource(byte[] data, string fileName, string contentType)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name cannot be empty.", nameof(fileName));
            }

            if (String.IsNullOrEmpty(contentType))
            {
                throw new ArgumentException("Content type cannot be empty.", nameof(contentType));
            }

            Data = data;
            FileName = fileName;
            ContentType = contentType;
            CreatesNewStream = true;
        }


        public FileContentSource(string filePath, string contentType)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File name cannot be empty.", nameof(filePath));
            }

            if (String.IsNullOrEmpty(contentType))
            {
                throw new ArgumentException("Content type cannot be empty.", nameof(contentType));
            }


            FilePath = filePath;
            FileName = Path.GetFileName(FilePath);
            ContentType = contentType;
            CreatesNewStream = true;
        }

        public FileContentSource(Stream stream, string fileName, string contentType)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (String.IsNullOrEmpty(contentType))
            {
                throw new ArgumentException("Content type cannot be empty.", nameof(contentType));
            }

            Stream = stream;
            FileName = fileName;
            ContentType = contentType;
        }
   }
}