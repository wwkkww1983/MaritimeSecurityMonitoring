   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null(    "MaritimeSecurityMonitoring.AISPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  AISPage�� N� 
Background
 ���� .��� $��200 50 200 80q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��2.5* �.+�� $��0��.+��� $��AIS.png��$��40���� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve$��Center=�$��18(�$��20 0 0 0q�	A  I  S�� $��1��   CommonGroupBox#��[  $��基本信息��$��0 30 0 0q�.���  �� $��0.45* ��� $��* ��� $��* ��� $
��0.4* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��1��$��0��$��16(�$��Center=�$��Center=�$��40 0 0 0q�IP地址：�� $��1��$��1��$��16(�$��Center=�$
��Left=�192.6.1.187�� $��1��$��2��$��16(�$��Center=�$��Center=�$��26 0 0 0q�	厂商：�� $��1��$��3��$��16(�$��Center=�$
��Left=�--�� $��2��$��0��$��16(�$��Center=�$��Center=�$��58 0 0 0q�产品名称：�� $��2��$��1��$��16(�$��Center=�$
��Left=�--�� $��2��$��2��$��16(�$��Center=�$��Center=�$��58 0 0 0q�产品系列：�� $��2��$��3��$��16(�$��Center=�$
��Left=�--�� $��2��#��[  $��工作状态��$��0 40 0 0q�.���  �� $��0.45* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.5* � �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��1��$��0��$��16(�$��Center=�$��Center=�$��58 0 0 0q�整机状体：�� -   $��AISStr��$��1��$��1��$��16(�$��Center=�$
��Left=�正常�� $��1��$��2��$��16(�$��Center=�$��Center=�$��40 0 0 0q�GPS：�� -   $��	sensorStr��$��1��$��3��$��16(�$��Center=�$
��Left=�正常�� $��2��$��0��$��16(�$��Center=�$��Center=�$��91 0 0 0q�收发器 / 天线：�� -   $��	channeStr��$��2��$��1��$��16(�$��Center=�$
��Left=�正常�� $��2��$��2��$��16(�$��Center=�$��Center=�$��58 0 0 0q�信息检测：�� -   $��informationStr��$��2��$��3��$��16(�$��Center=�$
��Left=�正常�� $��3��$��0��$��16(�$��Center=�$��Center=�$��58 0 0 0q�通用模块：�� -   $��
genaralStr��$��3��$��1��$��16(�$��Center=�$
��Left=�正常�� $��3��$��2��$��16(�$��Center=�$��Center=�$��26 0 0 0q�	时钟：�� -   $��clockStr��$��3��$��3��$��16(�$��Center=�$
��Left=�正常�� $��4��$��0��$��0��$��16(�$��Center=�$��Center=�$��66 0 0 0q�MKD连接：�� -   $��MKDStr��$��4��$��0��$��1��$��16(�$��Center=�$
��Left=�正常�� $��4��$��0��$��2��$��16(�$��Center=�$��Center=�$��26 0 0 0q�	其他：�� $��4��$��0��$��3��$��16(�$��Center=�$
��Left=�--�� $��4��$��0��$��16(�$��Center=�$��Center=�$��
77,11,13,7q�外部EPFS：�� -   $��EPFSStr��$��4��$��1��$��16(�$��Center=�$
��Left=�$��0,11,0,7q�正常