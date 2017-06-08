using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// WarnAreaSetting.xaml 的交互逻辑
    /// </summary>
    public partial class WarnAreaSetting : Window
    {
        private ObservableCollection<PolygonArea> polygonAreaList = new ObservableCollection<PolygonArea>();
        private ObservableCollection<PipelineArea> pipelineAreaList = new ObservableCollection<PipelineArea>();
        List<YimaWF.data.ForbiddenZone> list_poly;
        List<YimaWF.data.Pipeline> list_pipe;
        int geoFactor = 0;
        int[] polyID;
        int[] pipeID;
        int GetgeoFactor()
        {
            App app = (App)App.Current;
            return geoFactor = app.chartCtrl.GetGeoMultiFactor();
        }
        public void Update_PolyAndPipe_FromDB()
            //从数据库得到最新的数据
        {
            try
            {
                
                polyID = new int[5];
                pipeID = new int[5];
                
                dataAnadll.PolygonAreaManager polymanage = new dataAnadll.PolygonAreaManager();
                 list_poly = polymanage.GetAllPolygonArea(GetgeoFactor());
                polygonAreaList.Clear();
                pipelineAreaList.Clear();
                for (int i = 0; i < list_poly.Count; i++)
                {
                    PolygonArea pga = new PolygonArea
                    {
                        ID = list_poly[i].ID.ToString(),
                        Name = list_poly[i].Name,
                        Level = list_poly[i].AlarmLevel.ToString(),
                        Description = list_poly[i].Remark,
                        ReadOnly = true,
                    };
                    polyID[i] = Convert.ToInt32(pga.ID);
                    polygonAreaList.Add(pga);
                }
                for (int i = list_poly.Count; i < 5; i++)
                {
                    PolygonArea pga = new PolygonArea
                    {
                        ID = "",
                        Name = "",
                        Level = "",
                        Description = "",
                        ReadOnly = true,
                    };
                    try
                    {
                        polyID[i] = Convert.ToInt32(pga.ID);
                    }
                    catch
                    {
                        polyID[i] = 0;
                    }
                    polygonAreaList.Add(pga);
                }


                list_pipe = (new dataAnadll.PipeLineProtectAreaManager()).GetAllPipeLineProtectArea(GetgeoFactor());//管道所有目标

                for (int i = 0; i < list_pipe.Count; i++)
                {
                    PipelineArea pla = new PipelineArea
                    {
                        ID = list_pipe[i].ID.ToString(),
                        Name = list_pipe[i].Name.ToString(),
                        Width = list_pipe[i].width.ToString(),
                        Level = list_pipe[i].AlarmLevel.ToString(),
                        Description = list_pipe[i].Remark.ToString(),
                        ReadOnly = true,
                    };
                    pipeID[i] = Convert.ToInt32(pla.ID);
                    pipelineAreaList.Add(pla);
                }
                for (int i = list_pipe.Count; i < 5; i++)
                {
                    PipelineArea pla = new PipelineArea
                    {
                        ID = "",
                        Name = "",
                        Width = "",
                        Level = "",
                        Description = "",
                        ReadOnly = true,
                    };
                    pipelineAreaList.Add(pla);
                    try
                    {
                        pipeID[i] = Convert.ToInt32(pla.ID);
                    }
                    catch
                    {
                        pipeID[i] = 0;
                    }

                }
                PipelineDataGrid.DataContext = pipelineAreaList;
                PolygonDataGrid.DataContext = polygonAreaList;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           
        }
        public WarnAreaSetting()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;       
            Update_PolyAndPipe_FromDB();
           // PolygonDataGrid.LostFocus +=Update_Poly_ToDB;
           // PipelineDataGrid.LostFocus += Update_Pipe_ToDB;
           for(int i = 0; i < 5; i++)
            {
                if (String.IsNullOrWhiteSpace(polygonAreaList[i].ID))
                {
                    ToggleButton tb = FindName("tb" + i.ToString()) as ToggleButton;
                    Button b = FindName("b" + i.ToString()) as Button;
                    tb.IsEnabled = false;
                    b.IsEnabled = false;
                }
            }
        }
        

        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }

        private void PolygonClick(object sender, RoutedEventArgs e)
        {
            polygonBtn.IsEnabled = false;
            pipelineBtn.IsEnabled = true;
            PolygonDataGrid.Visibility = Visibility.Visible;
            PipelineDataGrid.Visibility = Visibility.Collapsed;
            for (int i = 0; i < 5; i++)
            {
                ToggleButton tb = FindName("tb" + i.ToString()) as ToggleButton;
                Button b = FindName("b" + i.ToString()) as Button;
                if (String.IsNullOrWhiteSpace(polygonAreaList[i].ID))
                {
                    tb.IsEnabled = false;
                    b.IsEnabled = false;
                }
                else
                {
                    tb.IsEnabled = true;
                    b.IsEnabled = true;
                    tb.IsChecked = !polygonAreaList[i].ReadOnly;
                }
            }
        }

        private void PipelineClick(object sender, RoutedEventArgs e)
        {
            polygonBtn.IsEnabled = true;
            pipelineBtn.IsEnabled = false;
            PolygonDataGrid.Visibility = Visibility.Collapsed;
            PipelineDataGrid.Visibility = Visibility.Visible;
            for (int i = 0; i < 5; i++)
            {
                ToggleButton tb = FindName("tb" + i.ToString()) as ToggleButton;
                Button b = FindName("b" + i.ToString()) as Button;
                if (String.IsNullOrWhiteSpace(pipelineAreaList[i].ID))
                {
                    tb.IsEnabled = false;
                    b.IsEnabled = false;
                }
                else
                {
                    tb.IsEnabled = true;
                    b.IsEnabled = true;
                    tb.IsChecked = !pipelineAreaList[i].ReadOnly;
                }
            }
        }
        private void Update_Poly_ToDB(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < polygonAreaList.Count; i++)
                {
                    if (i >= list_poly.Count)
                    {
                        continue;
                    }
                    YimaWF.data.ForbiddenZone fz = new YimaWF.data.ForbiddenZone();
                    TextBox tb10 = FindName(PolygonDataGrid, 0, i,  "id") as TextBox;
                    TextBox tb11 = FindName(PolygonDataGrid, 1,i,  "name") as TextBox;
                    TextBox tb12 = FindName(PolygonDataGrid, 2,i,  "level") as TextBox;
                    TextBox tb13 = FindName(PolygonDataGrid, 3,i,  "note") as TextBox;
                    fz.ID = Convert.ToInt32(tb10.Text);
                    if (fz.ID < 200 || fz.ID > 255)
                    {
                        continue;
                    }
                    fz.Name = tb11.Text;
                    fz.AlarmLevel = Convert.ToInt32(tb12.Text);
                    fz.Remark = tb13.Text;
                    fz.PointList = list_poly[i].PointList;
                    (new dataAnadll.PolygonAreaManager()).UpdatePolygonArea(fz, GetgeoFactor());
                }
                Update_PolyAndPipe_FromDB();
            }
            catch (Exception ee)
            {

            }
        }
        private void Update_Pipe_ToDB(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < pipelineAreaList.Count; i++)
                {
                    if (i >= list_pipe.Count)
                    {
                        continue;
                    }
                    YimaWF.data.Pipeline pl = new YimaWF.data.Pipeline();
                    TextBox tb10 = FindName(PipelineDataGrid,  0,i, "id") as TextBox;
                    TextBox tb11 = FindName(PipelineDataGrid,  1,i, "name") as TextBox;
                    TextBox tb_width = FindName(PipelineDataGrid, 2, i, "width") as TextBox;
                    TextBox tb12 = FindName(PipelineDataGrid,  3,i, "level") as TextBox;
                    TextBox tb13 = FindName(PipelineDataGrid,  4,i, "note") as TextBox;
                    pl.ID = Convert.ToInt32(tb10.Text);
                    if (pl.ID < 200 || pl.ID > 255)
                    {
                        continue;

                    }
                    pl.Name = tb11.Text;
                    pl.AlarmLevel = Convert.ToInt32(tb12.Text);
                    pl.Remark = tb13.Text;
                    pl.PointList = list_pipe[i].PointList;
                    pl.width = Convert.ToInt32(tb_width.Text);
                    (new dataAnadll.PipeLineProtectAreaManager()).UpdatePipeLineProtectArea(pl, GetgeoFactor());
                }
                Update_PolyAndPipe_FromDB();
            }
            catch (Exception ee)
            {
            }
           
        }
        private void Edit_Click(object sender, RoutedEventArgs e)//行编辑
        {
            ToggleButton b = sender as ToggleButton;
            int index = int.Parse(b.Tag.ToString());
            if (!polygonBtn.IsEnabled)
            {
                polygonAreaList[index].ReadOnly = !(bool)b.IsChecked;
                if (!polygonAreaList[index].ReadOnly)
                {
                    TextBox tb = FindName(PolygonDataGrid, 1, index, "name") as TextBox;
                    tb.Focus();
                    tb.SelectionStart = tb.Text.Length;

                    for(int i = 0; i < 5; i++)
                    {
                        if (index != i)
                        {
                            ToggleButton bt = FindName("tb" + i.ToString()) as ToggleButton;
                            bt.IsChecked = false;
                            polygonAreaList[i].ReadOnly = !(bool)bt.IsChecked;
                        }
                    }
                }
                else//区域同名检测  2017/6/5 14:45
                {
                    bool isNameSame = false;
                    TextBox tb = FindName(PolygonDataGrid, 1, index, "name") as TextBox;
                    for (int i = 0; !String.IsNullOrWhiteSpace(polygonAreaList[i].ID); i++)
                    {
                        if (index != i && polygonAreaList[i].Name == tb.Text)
                        {
                            isNameSame = true;
                            break;
                        }
                    }
                    for (int i = 0; !String.IsNullOrWhiteSpace(pipelineAreaList[i].ID); i++)
                    {
                        if (pipelineAreaList[i].Name == tb.Text)
                        {
                            isNameSame = true;
                            break;
                        }
                    }
                    if(isNameSame)
                    {
                        MessageBoxX.Show("提示", "名称已存在，请修改命名！");
                        polygonAreaList[index].ReadOnly = false;
                        b.IsChecked = true;
                        tb.Focus();
                        tb.SelectionStart = tb.Text.Length;
                    }
                    else
                    {
                        Update_Poly_ToDB(sender, e);
                    }
                }
            }
            else
            {
                pipelineAreaList[index].ReadOnly = !(bool)b.IsChecked;
                if (!pipelineAreaList[index].ReadOnly)
                {
                    TextBox tb = FindName(PipelineDataGrid, 1, index, "name") as TextBox;
                    tb.Focus();
                    tb.SelectionStart = tb.Text.Length;

                    for (int i = 0; i < 5; i++)
                    {
                        if (index != i)
                        {
                            ToggleButton bt = FindName("tb" + i.ToString()) as ToggleButton;
                            bt.IsChecked = false;
                            pipelineAreaList[i].ReadOnly = !(bool)bt.IsChecked;
                        }
                    }
                }
                else//区域同名检测  2017/6/5 14:45
                {
                    bool isNameSame = false;
                    TextBox tb = FindName(PipelineDataGrid, 1, index, "name") as TextBox;
                    for (int i = 0; !String.IsNullOrWhiteSpace(pipelineAreaList[i].ID); i++)
                    {
                        if (index != i && pipelineAreaList[i].Name == tb.Text)
                        {
                            isNameSame = true;
                            break;
                        }
                    }
                    for (int i = 0; !String.IsNullOrWhiteSpace(polygonAreaList[i].ID); i++)
                    {
                        if (polygonAreaList[i].Name == tb.Text)
                        {
                            isNameSame = true;
                            break;
                        }
                    }
                    if (isNameSame)
                    {
                        MessageBoxX.Show("提示", "名称已存在，请修改命名！");
                        pipelineAreaList[index].ReadOnly = false;
                        b.IsChecked = true;
                        tb.Focus();
                        tb.SelectionStart = tb.Text.Length;
                    }
                    else
                    {
                        TextBox tbw = FindName(PipelineDataGrid, 2, index, "width") as TextBox;
                        float ftry;
                        if (!String.IsNullOrWhiteSpace(tbw.Text) && float.TryParse(tbw.Text, out ftry))
                        {
                            if (ftry > 0 && ftry <= 100)
                                Update_Pipe_ToDB(sender, e);
                            else
                            {
                                MessageBoxX.Show("提示", "宽度超出范围！");
                                pipelineAreaList[index].ReadOnly = false;
                                b.IsChecked = true;
                                tbw.Focus();
                                tbw.SelectionStart = tbw.Text.Length;
                            }
                        }
                        else
                        {
                            MessageBoxX.Show("警告", "宽度数据非法！");
                            pipelineAreaList[index].ReadOnly = false;
                            b.IsChecked = true;
                            tbw.Focus();
                            tbw.SelectionStart = tbw.Text.Length;
                        }
                    }
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)//行删除
        {
            try
            {
                Button b = sender as Button;
                int index = int.Parse(b.Tag.ToString());
                App app = (App)App.Current;

                if (!polygonBtn.IsEnabled)
                {
                    //MainWindow.data.removePolygonAeraByName(MainWindow.mycon, polygonAreaList[index].Name);//数据库删除多边形
                    YimaWF.data.ForbiddenZone fz = new YimaWF.data.ForbiddenZone();
                    fz.ID = Convert.ToInt32(polygonAreaList[index].ID);
                    (new dataAnadll.PolygonAreaManager()).DeletePolygonArea(fz);
                    int num = (int)double.Parse(polygonAreaList[index].ID) - 210;
                    MonitoringX.deleteForbiddenZone(polygonAreaList[index].Name, num);//显控同步+海图删除
                    polygonAreaList[index].ID = null;
                    polygonAreaList[index].Name = null;
                    polygonAreaList[index].Level = null;
                    polygonAreaList[index].Description = null;
                    polygonAreaList[index].ReadOnly = true;
                    polyID[index] = 0;
                }
                else
                {
                    //MainWindow.data.removeProtectAeraByName(MainWindow.mycon, pipelineAreaList[index].Name);//数据库删除管道
                    YimaWF.data.Pipeline pl = new YimaWF.data.Pipeline();
                    pl.ID = Convert.ToInt32(pipelineAreaList[index].ID);
                    (new dataAnadll.PipeLineProtectAreaManager()).DeletePipeLineProtectArea(pl);
                    int num = (int)double.Parse(pipelineAreaList[index].ID) - 220;
                    MonitoringX.deletePipeline(pipelineAreaList[index].Name, num);//显控同步+海图删除
                    pipelineAreaList[index].ID = null;
                    pipelineAreaList[index].Name = null;
                    pipelineAreaList[index].Width = null;
                    pipelineAreaList[index].Level = null;
                    pipelineAreaList[index].Description = null;
                    pipelineAreaList[index].ReadOnly = true;
                    pipeID[index] = 0;
                }
                Update_PolyAndPipe_FromDB();

                if (!polygonBtn.IsEnabled)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ToggleButton tb = FindName("tb" + i.ToString()) as ToggleButton;
                        Button bt = FindName("b" + i.ToString()) as Button;
                        if (String.IsNullOrWhiteSpace(polygonAreaList[i].ID))
                        {
                            tb.IsChecked = false;
                            tb.IsEnabled = false;
                            bt.IsEnabled = false;
                        }
                        else
                        {
                            tb.IsChecked = false;
                            tb.IsEnabled = true;
                            bt.IsEnabled = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ToggleButton tb = FindName("tb" + i.ToString()) as ToggleButton;
                        Button bt = FindName("b" + i.ToString()) as Button;
                        if (String.IsNullOrWhiteSpace(pipelineAreaList[i].ID))
                        {
                            tb.IsChecked = false;
                            tb.IsEnabled = false;
                            bt.IsEnabled = false;
                        }
                        else
                        {
                            tb.IsChecked = false;
                            tb.IsEnabled = true;
                            bt.IsEnabled = true;
                        }
                    }
                }
            }
            catch (Exception ee)
            {

            }

        }

        public object FindName(DataGrid myDataGrid, int columnIndex, int rowIndex, string controlName)
        {
            FrameworkElement item = myDataGrid.Columns[columnIndex].GetCellContent(myDataGrid.Items[rowIndex]);
            DataGridTemplateColumn temp = (myDataGrid.Columns[columnIndex] as DataGridTemplateColumn);
            return temp.CellTemplate.FindName(controlName, item);
        }

        private void PolygonDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
