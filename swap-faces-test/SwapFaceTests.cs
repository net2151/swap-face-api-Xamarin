using SwapFaces;
using NUnit.Framework;
using System.Threading.Tasks;
using SwapFaces.Swap;
using SwapFaces.Helpers;
using SwapFaces.Dto;
using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Diagnostics;

namespace SwapFacesTest
{
    public class SwapFaceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_Integration_YTVideo_ImageUrl_FrameAt_Trim_SingleFace()
        {
            var shellHelper = new ShellHelper();
            var swap = new SwapFaceProcessor(new ImageDownloader(), new YoutubeHelper(shellHelper), new FfMpegHelper(shellHelper), shellHelper);
            var request = new SwapFacesRequest()
            {
                SuperResolution = true,
                TargetMedia = new TargetMedia()
                {
                    MediaType = MediaType.Video,
                    SourceType = TargetMediaSourceType.Url,
                    Id = "https://www.youtube.com/watch?v=NMvMR-jNSKg",
                    StartAtTime = "00:00:07",
                    EndAtTime = "00:00:27"
                },
                SwapFaces = new List<SwapFace>()
                {
                    new SwapFace()
                    {
                        SourceType = FaceFromType.ImageUrl,
                        SourceId = "https://i.imgur.com/hES7D98.jpeg",
                        TargetType = FaceFromType.FrameAtTarget,
                        TargetId = "00:00:15.500"
                    }
                }
            };
            var result = await swap.Process(request, null);


            Console.WriteLine("REQUEST: ");
            Console.WriteLine(JsonSerializer.Serialize(request, new JsonSerializerOptions() { WriteIndented = true }));
            Console.WriteLine("");
            Console.WriteLine("RESULT: ");
            Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions() { WriteIndented = true }));
        }
    }
}
