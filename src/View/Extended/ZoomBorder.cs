using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace WpfControlsDemo.View.Extended
{
    // This 'ZoomBoeder' is the image holder
    // Supporting: 'Pan(DragMove)' and 'Zoom(Scaling)'
    public class ZoomBorder : Border
    {
        private UIElement child = null;
        private Point imageTransOrigin;
        private Point mouseMoveStart;

        private TranslateTransform GetTranslateTransform(UIElement element)
        {
            return (TranslateTransform)((TransformGroup)element.RenderTransform).Children.First(tr => tr is TranslateTransform);
        }

        private ScaleTransform GetScaleTransform(UIElement element)
        {
            return (ScaleTransform)((TransformGroup)element.RenderTransform).Children.First(tr => tr is ScaleTransform);
        }

        public override UIElement Child
        {
            get
            {
                return base.Child;
            }
            set
            {
                if (value != null && value != this.Child)
                {
                    this.Initialize(value);
                }

                base.Child = value;
            }
        }

        public void Initialize(UIElement element)
        {
            this.child = element;
            if (child != null)
            {
                TransformGroup group = new TransformGroup();
                ScaleTransform st = new ScaleTransform();
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(st);
                group.Children.Add(tt);
                child.RenderTransform = group;
                child.RenderTransformOrigin = new Point(0.0, 0.0);

                this.MouseWheel += child_MouseWheel;
                this.MouseLeftButtonDown += child_MouseLeftButtonDown;
                this.MouseLeftButtonUp += child_MouseLeftButtonUp;
                this.MouseMove += child_MouseMove;
                this.PreviewMouseRightButtonUp += new MouseButtonEventHandler(child_PreviewMouseRightButtonUp);
            }
        }

        /// <summary>
        /// Reset Image Zoom and Pan
        /// </summary>
        public void Reset()
        {
            if (child != null)
            {
                // reset zoom
                var st = GetScaleTransform(child);
                st.ScaleX = 1.0;
                st.ScaleY = 1.0;

                // reset pan
                var tt = GetTranslateTransform(child);
                tt.X = 0.0;
                tt.Y = 0.0;
            }
        }

        #region MouseActions

        private void child_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (child != null)
            {
                var st = GetScaleTransform(child);

                double scale = st.ScaleX;

                if (e.Delta < 0) // scale down
                {
                    if (scale < 0.2)
                    {
                        return;
                    }
                    else if (scale <= 1.0)
                    {
                        scale -= 0.1;
                    }
                    else
                    {
                        scale -= 0.5;
                    }
                }
                else if (e.Delta > 0) // scale up
                {
                    if (scale >= 20.0)
                    {
                        return;
                    }
                    else if (scale >= 1.0)
                    {
                        scale += 0.5;
                    }
                    else
                    {
                        scale += 0.2;
                    }
                }

                Point relative = e.GetPosition(child);

                var tt = GetTranslateTransform(child);

                double abosuluteX = relative.X * st.ScaleX + tt.X;
                double abosuluteY = relative.Y * st.ScaleY + tt.Y;

                st.ScaleX = st.ScaleY = scale;

                tt.X = abosuluteX - relative.X * st.ScaleX;
                tt.Y = abosuluteY - relative.Y * st.ScaleY;
            }
        }

        private void child_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (child != null)
            {
                var tt = GetTranslateTransform(child);
                mouseMoveStart = e.GetPosition(this);
                imageTransOrigin = new Point(tt.X, tt.Y);
                this.Cursor = Cursors.Hand;
                child.CaptureMouse();
            }
        }

        private void child_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (child != null)
            {
                child.ReleaseMouseCapture();
                this.Cursor = Cursors.Arrow;
            }
        }

        void child_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Reset();
        }

        private void child_MouseMove(object sender, MouseEventArgs e)
        {
            if (child != null)
            {
                if (child.IsMouseCaptured)
                {
                    var tt = GetTranslateTransform(child);
                    Vector v = mouseMoveStart - e.GetPosition(this);
                    tt.X = imageTransOrigin.X - v.X;
                    tt.Y = imageTransOrigin.Y - v.Y;
                }
            }
        }

        #endregion MouseActions
    }
}
