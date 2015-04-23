using System;
using System.Collections.Generic;
using BowlingBE.Models;
using BowlingBE.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BowlingBE.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestNoFrames()
        {
            BowlingFrames bowlingFrames = new BowlingFrames(new List<BowlingFrame>());
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(0, br.CountScore().Score, "Test No Frames");
        }
        
        [TestMethod]
        public void TestZeroFrame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>() { new BowlingFrame(0, 0) };
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(0, br.CountScore().Score, "Test Zero-Frame");
        }

        [TestMethod]
        public void TestOneFrame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>() { new BowlingFrame(1, 2) };
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(3, br.CountScore().Score, "Test One Frame");
        }
        
        [TestMethod]
        public void TestTenFrame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>() { new BowlingFrame(1, 1), new BowlingFrame(1, 1), new BowlingFrame(1, 1), new BowlingFrame(1, 1), new BowlingFrame(1, 1), new BowlingFrame(1, 1), new BowlingFrame(1, 1), new BowlingFrame(1, 1), new BowlingFrame(1, 1), new BowlingFrame(1, 1) };
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(20, br.CountScore().Score, "Test Ten Frames");
        }

        // Spares
        [TestMethod]
        public void TestSpareFrame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(6, 4));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(10, br.CountScore().Score, "Test Spare Frame");
        }

        [TestMethod]
        public void TestSpareFrameWithFollowingFrame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(6, 4));
            list.Add(new BowlingFrame(5, 3));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(23, br.CountScore().Score, "Test Spare Frame with a frame that follows");
        }

        [TestMethod]
        public void TestTwoSparesInARow()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(6, 4));
            list.Add(new BowlingFrame(5, 5));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(25, br.CountScore().Score, "Test Two Spares in a row");
        }

        //Strikes
        [TestMethod]
        public void TestStrikeFrame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(10, 0));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(10, br.CountScore().Score, "Test Strike Frame");
        }

        [TestMethod]
        public void TestStrikeFrameWithFollowingFrame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(5, 3));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(26, br.CountScore().Score, "Test Strike Frame with a regular following frame");
        }

        [TestMethod]
        public void TestTwoStrikesInARow()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(30, br.CountScore().Score, "Test Two Strikes in a row");
        }

        [TestMethod]
        public void TestTwoStrikesInARowFollowedByNormal()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(3,5));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(49, br.CountScore().Score, "Test Two Strikes in a row then a normal one");
        }

        [TestMethod]
        public void TestThreeStrikesInARow()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(60, br.CountScore().Score, "Test three strikes in a row");
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 0));
            list.Add(new BowlingFrame(10, 10));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(300, br.CountScore().Score, "Test Perfect Game");
        }

        [TestMethod]
        public void TestAllSparesGame()
        {
            List<BowlingFrame> list = new List<BowlingFrame>();
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9));
            list.Add(new BowlingFrame(1, 9, 1));
            BowlingFrames bowlingFrames = new BowlingFrames(list);
            var br = new BowlingRepository(bowlingFrames);
            Assert.AreEqual(110, br.CountScore().Score, "Test All Spares Game");
        }
    }
}
