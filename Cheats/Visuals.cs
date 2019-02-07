using System;
using System.Drawing;
using System.Numerics;
using GameOverlay.Graphics;
using GameOverlay.Graphics.Primitives;
using GameOverlay.Utilities;
using GameOverlay.Windows;
using ZBase.Classes;
using ZBase.Utilities;
using Point = GameOverlay.Graphics.Primitives.Point;
using Rectangle = GameOverlay.Graphics.Primitives.Rectangle;

namespace ZBase.Cheats
{
    public class Visuals
    {
        #region dx shid
        private OverlayWindow _window;
        private D2DDevice _device;
        private FrameTimer _frameTimer;
        private bool _initializeGraphicObjects;

        public Visuals()
        {
            SetupInstance();
        }

        ~Visuals()
        {
            DestroyInstance();
        }

        private void SetupInstance()
        {
            _window = new OverlayWindow(new OverlayOptions()
            {
                BypassTopmost = false,
                Height = (int)(Main.ScreenSize.Height),
                Width = (int)(Main.ScreenSize.Width),
                WindowTitle = "Overlay",
                X = 0,
                Y = 0,
            });

            _device = new D2DDevice(new DeviceOptions()
            {
                AntiAliasing = true,
                Hwnd = _window.WindowHandle,
                MeasureFps = false,
                MultiThreaded = false,
                VSync = false
            });

            _frameTimer = new FrameTimer(_device, 0);

            _initializeGraphicObjects = true;

            _frameTimer.OnFrameStarting += _frameTimer_OnFrameStarting;
            _frameTimer.OnFrame += _frameTimer_OnFrame;

            _frameTimer.Start();
        }

        public void DestroyInstance()
        {
            _frameTimer.Stop();

            _frameTimer.Dispose();
            _device.Dispose();
            _window.Dispose();
            _device = null;
            _frameTimer = null;
        }

        private void _frameTimer_OnFrameStarting(FrameTimer timer, D2DDevice device)
        {
            if (!_initializeGraphicObjects) return;

            if (!device.IsInitialized) return;
            if (device.IsDrawing) return;
            _initializeGraphicObjects = false;
        }

        #endregion
        private void _frameTimer_OnFrame(FrameTimer timer, D2DDevice device)
        {
            #region non drawing things
            D2DSolidColorBrush GetDXColor(Color color)
            {
                return device.CreateSolidColorBrush(color.R, color.G, color.B, color.A);
            }
            if (!device.IsDrawing)
            {
                _initializeGraphicObjects = true;
                return;
            }
            device.ClearScene();
            #endregion
            DrawTextWithBackground("ZBase", 0, 0, 16, Color.Blue, Color.DimGray);

            if (Main.S.ESP)
            {
                foreach (Entity Player in Globals.EntityList)
                {
                    if (Player.EntityBase != Globals.LocalPlayer.EntityBase)
                    {
                        Vector2 Player2DPos = Tools.WorldToScreen(Player.Position);
                        Vector2 Player2DHeadPos = Tools.WorldToScreen(Player.HeadPosition);
                        Vector2 Player2DNeckPos = Tools.WorldToScreen(Player.GetBonePosition(7));
                        if (!Tools.IsNullVector2(Player2DPos) && !Tools.IsNullVector2(Player2DHeadPos) && Player.Valid)
                        {
                            float FromHeadToNeck = (Player2DNeckPos.Y - Player2DHeadPos.Y);
                            Player2DHeadPos.Y -= FromHeadToNeck * 2.3f;
                            Player2DPos.Y += FromHeadToNeck;
                            float BoxHeight = Player2DPos.Y - Player2DHeadPos.Y;
                            float BoxWidth = (BoxHeight / 2);
                            //wierd ass calculations for box height, dont judge
                            Color drawcolor;
                            if (Player.IsTeammate)
                                drawcolor = Color.Blue;
                            else
                                drawcolor = Color.Red;
                            DrawOutlineBox(Player2DPos.X - (BoxWidth / 2), Player2DHeadPos.Y, BoxWidth, BoxHeight, drawcolor);
                            DrawLine(Main.MidScreen.X, Main.MidScreen.Y + Main.MidScreen.Y, Player2DPos.X, Player2DPos.Y, drawcolor);
                        }
                    }
                }
            }

            #region drawing functions
            void DrawBoxEdge(float x, float y, float width, float height, Color color, float thiccness = 2.0f)
            {
                device.DrawRectangleEdges(Rectangle.Create(x, y, width, height), thiccness, GetDXColor(color));
            }

            void DrawText(string text, float x, float y, int size, Color color, bool bold = false, bool italic = false)
            {
                D2DFont f = _device.CreateFont(new FontOptions()
                {
                    Bold = bold,
                    FontFamilyName = "Arial",
                    FontSize = size,
                    Italic = italic,
                    WordWrapping = true
                });
                device.DrawText(text, new Point(x, y), f, GetDXColor(color));
            }

            void DrawTextWithBackground(string text, float x, float y, int size, Color color, Color backcolor, bool bold = false, bool italic = false)
            {
                D2DFont f = _device.CreateFont(new FontOptions()
                {
                    Bold = bold,
                    FontFamilyName = "Arial",
                    FontSize = size,
                    Italic = italic,
                    WordWrapping = true
                });
                device.DrawTextWithBackground(text, new Point(x, y), f, GetDXColor(color), GetDXColor(backcolor));
            }

            void DrawLine(float fromx, float fromy, float tox, float toy, Color color, float thiccness = 2.0f)
            {
                device.DrawLine(fromx, fromy, tox, toy, thiccness, GetDXColor(color));
            }

            void DrawFilledRectangle(float x, float y, float width, float height, Color color)
            {
                device.FillRectangle(Rectangle.Create(x, y, width, height), GetDXColor(color));
            }

            void DrawCircle(float x, float y, float radius, Color color)
            {
                device.DrawCircle(new Circle(x, y, radius), 1, GetDXColor(color));
            }

            void DrawCrosshair(CrosshairStyle style, float x, float y, float size, float stroke, Color color)
            {
                device.DrawCrosshair(style, new Point(x, y), size, stroke, GetDXColor(color));
            }

            void DrawBox(float x, float y, float width, float height, Color color, float thiccness = 2.0f)
            {
                device.DrawRectangle(Rectangle.Create(x, y, width, height), thiccness, GetDXColor(color));
            }

            void DrawOutlineBox(float x, float y, float width, float height, Color color, float thiccness = 2.0f)
            {
                device.OutlineRectangle(Rectangle.Create(x, y, width, height), thiccness, GetDXColor(color), GetDXColor(Color.Black));
            }

            void DrawRoundedBox(float x, float y, float width, float height, float radius, Color color, float thiccness = 2.0f)
            {
                device.DrawRoundedRectangle(RoundedRectangle.Create(x, y, width, height, radius), thiccness, GetDXColor(color));
            }
            #endregion
        }
    }
}
