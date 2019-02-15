using System;
using System.Numerics;
using GameOverlay.Drawing;
using GameOverlay.Windows;
using ZBase.Classes;
using ZBase.Utilities;
using Color = System.Drawing.Color;

namespace ZBase.Cheats
{
    public class Visuals
    {
        #region dx shid
        private OverlayWindow _window;
        private Graphics _graphics;

        public object Globals { get; private set; }

        public Visuals()
        {
            _window = new OverlayWindow(Main.ScreenRect.left, Main.ScreenRect.top, Main.ScreenSize.Width, Main.ScreenSize.Height)
            {
                IsTopmost = true,
                IsVisible = true
            };
            _window.SizeChanged += _window_SizeChanged;
            _graphics = new Graphics()
            {
                MeasureFPS = true,
                Height = _window.Height,
                PerPrimitiveAntiAliasing = true,
                TextAntiAliasing = true,
                UseMultiThreadedFactories = false,
                VSync = true,
                Width = _window.Width,
                WindowHandle = IntPtr.Zero
            };
        }

        ~Visuals()
        {
            _graphics.Dispose();
            _window.Dispose();
        }

        public void Initialize()
        {
            _window.CreateWindow();
            _graphics.WindowHandle = _window.Handle; // set the target handle before calling Setup()
            _graphics.Setup();
        }

        private void _window_SizeChanged(object sender, OverlaySizeEventArgs e)
        {
            if (_graphics == null) return;

            if (_graphics.IsInitialized)
            {
                // after the Graphics surface is initialized you can only use the Resize method in order to enqueue a size change
                _graphics.Resize(e.Width, e.Height);
            }
            else
            {
                // otherwise just set its members
                _graphics.Width = e.Width;
                _graphics.Height = e.Height;
            }
        }
        #endregion
        public void Run()
        {
            #region things
            var gfx = _graphics;
            SolidBrush GetBrushColor(Color color)
            {
                return gfx.CreateSolidBrush(color.R, color.G, color.B, color.A);
            }
            #endregion
            #region Draw
            while (true)
            {
                gfx.BeginScene();
                gfx.ClearScene();
                // start drawings here

                DrawTextWithBackground("ZBase", 0, 0, 18, Color.Maroon, Color.Black);
                if (Main.S.ESP)
                {
                    foreach (Entity Player in G.EntityList)
                    {
                        if (Player.EntityBase != G.Engine.LocalPlayer.EntityBase)
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

                                #region Box
                                //DrawOutlineBox(Player2DPos.X - (BoxWidth / 2), Player2DHeadPos.Y, BoxWidth, BoxHeight, drawcolor);
                                //DrawFillOutlineBox(Player2DPos.X - (BoxWidth / 2), Player2DHeadPos.Y, BoxWidth, BoxHeight, drawcolor, Color.FromArgb(50, 198, 198, 198));
                                DrawBoxEdge(Player2DPos.X - (BoxWidth / 2), Player2DHeadPos.Y, BoxWidth, BoxHeight, drawcolor, 1);
                                #endregion
                                #region Health Bar
                                float Health = Player.Health;
                                Color HealthColor = Tools.HealthGradient(Tools.HealthToPercent((int)Health));
                                float x = Player2DPos.X - (BoxWidth / 2) - 8;
                                float y = Player2DHeadPos.Y;
                                float w = 4;
                                float h = BoxHeight;
                                float HealthHeight = (Health * h) / 100;

                                DrawBox(x, y, w, h, Color.Black, 1);
                                DrawFilledBox(x + 1, y + 1, 2, HealthHeight - 1, HealthColor);
                                #endregion
                                #region Snaplines
                                DrawLine(Main.MidScreen.X, Main.MidScreen.Y + Main.MidScreen.Y, Player2DPos.X, Player2DPos.Y, drawcolor);
                                #endregion
                            }
                        }
                    }
                }

                

                //end drawings
                gfx.EndScene();
            }
            #endregion
            #region drawing functions
            void DrawBoxEdge(float x, float y, float width, float height, Color color, float thiccness = 2.0f)
            {
                gfx.DrawRectangleEdges(GetBrushColor(color), x, y, x + width, y + height, thiccness);
            }

            void DrawText(string text, float x, float y, int size, Color color, bool bold = false, bool italic = false)
            {
                if (Tools.InScreenPos(x, y))
                {
                    gfx.DrawText(_graphics.CreateFont("Arial", 16, bold, italic), GetBrushColor(color), x, y, text);
                }
            }

            void DrawTextWithBackground(string text, float x, float y, int size, Color color, Color backcolor, bool bold = false, bool italic = false)
            {
                if (Tools.InScreenPos(x, y))
                {
                    gfx.DrawTextWithBackground(_graphics.CreateFont("Arial", 16, bold, italic), GetBrushColor(color), GetBrushColor(backcolor), x, y, text);
                }
            }

            void DrawLine(float fromx, float fromy, float tox, float toy, Color color, float thiccness = 2.0f)
            {
                gfx.DrawLine(GetBrushColor(color), fromx, fromy, tox, toy, thiccness);
            }

            void DrawFilledBox(float x, float y, float width, float height, Color color)
            {
                gfx.FillRectangle(GetBrushColor(color), x, y, x + width, y + height);
            }

            void DrawCircle(float x, float y, float radius, Color color, float thiccness = 1)
            {
                gfx.DrawCircle(GetBrushColor(color), x, y, radius, thiccness);
            }

            void DrawCrosshair(CrosshairStyle style, float x, float y, float size, float thiccness, Color color)
            {
                gfx.DrawCrosshair(GetBrushColor(color), x, y, size, thiccness, style);
            }

            void DrawFillOutlineBox(float x, float y, float width, float height, Color color, Color fillcolor, float thiccness = 1.0f)
            {
                gfx.OutlineFillRectangle(GetBrushColor(color), GetBrushColor(fillcolor), x, y, x + width, y + height, thiccness);
            }

            void DrawBox(float x, float y, float width, float height, Color color, float thiccness = 2.0f)
            {
                gfx.DrawRectangle(GetBrushColor(color), x, y, x + width, y + height, thiccness);
            }

            void DrawOutlineBox(float x, float y, float width, float height, Color color, float thiccness = 2.0f)
            {
                gfx.OutlineRectangle(GetBrushColor(Color.FromArgb(0, 0, 0)), GetBrushColor(color), x, y, x + width, y + height, thiccness);
            }

            void DrawRoundedBox(float x, float y, float width, float height, float radius, Color color, float thiccness = 2.0f)
            {
                gfx.DrawRoundedRectangle(GetBrushColor(color), x, y, x + width, y + height, radius, thiccness);
            }
            #endregion
        }
    }
}
