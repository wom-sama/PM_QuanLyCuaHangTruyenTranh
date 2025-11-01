using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PM.GUI.Main
{
    public partial class AdminForm : Form
    {
        // ====== CẤU HÌNH ANIMATION ======
        private const int ANIM_STEP = 20;      // tốc độ di chuyển (px mỗi tick)
        private const int TIMER_INTERVAL = 15; // chu kỳ animation (ms)

        // ====== TRẠNG THÁI ======
        private bool isAnimating = false;
        private Guna2GradientTileButton openedLargeButton = null;

        private readonly Dictionary<Control, Point> originalPositions = new Dictionary<Control, Point>();
        private List<Guna2GradientTileButton> largeButtons = new List<Guna2GradientTileButton>();
        private List<Guna2GradientTileButton> smallButtons = new List<Guna2GradientTileButton>();

        // ====== TIMER ======
        private readonly Timer timerMove = new Timer();
        private AnimationTask currentTask = null;

        // ====== PANELCN ======
        private bool panelCNVisible = true;
        private readonly Timer timerPanelCN = new Timer();
        private int panelCNHiddenX;

        public AdminForm()
        {
            InitializeComponent();
            timerMove.Interval = TIMER_INTERVAL;
            timerMove.Tick += TimerMove_Tick;

            timerPanelCN.Interval = TIMER_INTERVAL;
            timerPanelCN.Tick += TimerPanelCN_Tick;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            
            // Lưu vị trí gốc của control trong PanelCN
            foreach (Control c in PanelCN.Controls)
                originalPositions[c] = c.Location;

            // ⚠️ Bổ sung thêm dòng này để lưu vị trí của shadow_PannelCN
            originalPositions[shadow_PannelCN] = shadow_PannelCN.Location;

            // Phân loại các nút lớn/nhỏ
            foreach (var c in shadow_PannelCN.Controls.OfType<Guna2GradientTileButton>())
            {
                if (c.Width > 153)
                    largeButtons.Add(c);
                else
                    smallButtons.Add(c);
            }

            largeButtons = largeButtons.OrderBy(b => b.Top).ToList();
            smallButtons = smallButtons.OrderBy(b => b.Top).ToList();

            // Ẩn nút nhỏ sang trái
            int hideLeft = -(smallButtons.Any() ? smallButtons.Max(b => b.Width) + 30 : 200);
            foreach (var s in smallButtons)
                s.Left = hideLeft;

            // Căn các nút lớn
            int y = largeButtons.FirstOrDefault()?.Top ?? 0;
            foreach (var l in largeButtons)
            {
                l.Top = y;
                y += l.Height + 6;
            }

            foreach (var l in largeButtons)
                l.Click += LargeButton_Click;

            btnCN.Click += BtnCN_Click;

            // Tính vị trí ẩn của PanelCN
            panelCNHiddenX = shadow_PannelCN.Left - shadow_PannelCN.Width - 200;

            openedLargeButton = null;
        }

        //=================== ANIMATION QUEUE ===================
        private class AnimationTask
        {
            public enum TaskType { OpenGroup, CloseGroup, SwitchGroup, PanelToggle }
            public TaskType Type;
            public Guna2GradientTileButton TargetLarge;
            public Guna2GradientTileButton NewLarge;
            public Action OnCompleted;
        }

        private void StartTask(AnimationTask task)
        {
            if (isAnimating) return;
            currentTask = task;
            isAnimating = true;
            timerMove.Start();
        }

        private void EndTask()
        {
            timerMove.Stop();
            isAnimating = false;
            currentTask = null;
        }

        //=================== CLICK LỚN ===================
        private void LargeButton_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            var btn = sender as Guna2GradientTileButton;
            if (btn == null) return;

            if (openedLargeButton == btn)
            {
                StartTask(new AnimationTask
                {
                    Type = AnimationTask.TaskType.CloseGroup,
                    TargetLarge = btn,
                    OnCompleted = () => openedLargeButton = null
                });
                return;
            }

            if (openedLargeButton != null && openedLargeButton != btn)
            {
                StartTask(new AnimationTask
                {
                    Type = AnimationTask.TaskType.SwitchGroup,
                    TargetLarge = openedLargeButton,
                    NewLarge = btn,
                    OnCompleted = () => openedLargeButton = btn
                });
                return;
            }

            StartTask(new AnimationTask
            {
                Type = AnimationTask.TaskType.OpenGroup,
                TargetLarge = btn,
                OnCompleted = () => openedLargeButton = btn
            });
        }

        //=================== PANELCN TOGGLE ===================
        private void BtnCN_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            currentTask = new AnimationTask
            {
                Type = AnimationTask.TaskType.PanelToggle
            };
            isAnimating = true;
            timerPanelCN.Start();
        }

        private void TimerPanelCN_Tick(object sender, EventArgs e)
        {
            int target = panelCNVisible ? panelCNHiddenX : originalPositions[shadow_PannelCN].X;
            int cur = shadow_PannelCN.Left;
            int dir = target > cur ? 1 : -1;
            int step = Math.Min(ANIM_STEP, Math.Abs(target - cur));
            shadow_PannelCN.Left = cur + dir * step;

            if (shadow_PannelCN.Left == target)
            {
                timerPanelCN.Stop();
                panelCNVisible = !panelCNVisible;
                isAnimating = false;
            }
        }

        //=================== CORE TICK ===================
        private void TimerMove_Tick(object sender, EventArgs e)
        {
            if (currentTask == null)
            {
                EndTask();
                return;
            }

            switch (currentTask.Type)
            {
                case AnimationTask.TaskType.OpenGroup:
                    if (AnimateOpenFrame(currentTask.TargetLarge))
                    {
                        EndTask();
                        currentTask.OnCompleted?.Invoke();
                    }
                    break;

                case AnimationTask.TaskType.CloseGroup:
                    if (AnimateCloseFrame(currentTask.TargetLarge))
                    {
                        EndTask();
                        currentTask.OnCompleted?.Invoke();
                    }
                    break;

                case AnimationTask.TaskType.SwitchGroup:
                    if (AnimateCloseFrame(currentTask.TargetLarge))
                    {
                        openedLargeButton = null;
                        currentTask.Type = AnimationTask.TaskType.OpenGroup;
                        currentTask.TargetLarge = currentTask.NewLarge;
                    }
                    break;

                default:
                    EndTask();
                    break;
            }
        }

        //=================== OPEN/CLOSE ===================
        private bool AnimateOpenFrame(Guna2GradientTileButton btn)
        {
            if (smallButtons.Count == 0) return true;

            int smallH = smallButtons.First().Height;
            int spacing = 6;
            int totalGap = smallButtons.Count * (smallH + spacing);

            bool allLargeAtTarget = true;
            foreach (var l in largeButtons)
            {
                if (l.Top <= btn.Top) continue;
                int targetTop = originalPositions[l].Y + totalGap;
                if (Math.Abs(l.Top - targetTop) > 0)
                {
                    int delta = Math.Min(ANIM_STEP, Math.Abs(targetTop - l.Top));
                    l.Top += Math.Sign(targetTop - l.Top) * delta;
                    allLargeAtTarget = false;
                }
            }

            bool allSmallAtTarget = true;
            for (int i = 0; i < smallButtons.Count; i++)
            {
                var s = smallButtons[i];
                int targetLeft = originalPositions[btn].X;
                int targetTop = btn.Top + btn.Height + i * (smallH + spacing);

                if (Math.Abs(s.Left - targetLeft) > 0)
                {
                    int step = Math.Min(ANIM_STEP, Math.Abs(targetLeft - s.Left));
                    s.Left += Math.Sign(targetLeft - s.Left) * step;
                    allSmallAtTarget = false;
                }

                if (Math.Abs(s.Top - targetTop) > 0)
                {
                    int step = Math.Min(ANIM_STEP, Math.Abs(targetTop - s.Top));
                    s.Top += Math.Sign(targetTop - s.Top) * step;
                    allSmallAtTarget = false;
                }
            }

            return allLargeAtTarget && allSmallAtTarget;
        }

        private bool AnimateCloseFrame(Guna2GradientTileButton btn)
        {
            int hideLeft = -(smallButtons.Any() ? smallButtons.Max(b => b.Width) + 30 : 200);

            bool allSmallHidden = true;
            foreach (var s in smallButtons)
            {
                if (Math.Abs(s.Left - hideLeft) > 0)
                {
                    int step = Math.Min(ANIM_STEP, Math.Abs(s.Left - hideLeft));
                    s.Left -= Math.Sign(s.Left - hideLeft) * step;
                    allSmallHidden = false;
                }
            }

            bool allLargeAtOrig = true;
            foreach (var l in largeButtons)
            {
                int origTop = originalPositions[l].Y;
                if (Math.Abs(l.Top - origTop) > 0)
                {
                    int step = Math.Min(ANIM_STEP, Math.Abs(l.Top - origTop));
                    l.Top -= Math.Sign(l.Top - origTop) * step;
                    allLargeAtOrig = false;
                }
            }

            return allSmallHidden && allLargeAtOrig;
        }

        //=================== UTILITIES ===================
        private void ForceCloseCurrent()
        {
            if (openedLargeButton == null) return;

            int hideLeft = -(smallButtons.Any() ? smallButtons.Max(b => b.Width) + 30 : 200);
            foreach (var s in smallButtons)
                s.Left = hideLeft;

            foreach (var l in largeButtons)
                l.Top = originalPositions[l].Y;

            openedLargeButton = null;
        }
    }
}
