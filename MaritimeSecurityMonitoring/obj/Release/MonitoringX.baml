   M S B A M L   `   `   `  ���� H  DNVRCsharpDemo, Version=2.0.1.1, Culture=neutral, PublicKeyToken=nullD2clr-namespace:NVRCsharpDemo;assembly=NVRCsharpDemoNVRCsharpDemo  ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms A =YimaWF, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null/$clr-namespace:YimaWF;assembly=YimaWFYimaWF O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem U QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring >   8MaritimeSecurityMonitoring.MainInterfacePage.MonitoringX   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	    @d2http://schemas.microsoft.com/expression/blend/2008 	    BDVR2clr-namespace:NVRCsharpDemo;assembly=NVRCsharpDemo 	    _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration 	    Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms 	    3ym$clr-namespace:YimaWF;assembly=YimaWF 	    6clr&clr-namespace:System;assembly=mscorlib 	    :local(clr-namespace:MaritimeSecurityMonitoring 	    -     N� Title$  MonitoringX�� N� ShowsNavigationUI .   N� 	KeepAlive .  � 	Resources 8 2MaritimeSecurityMonitoring.SourceToStringConverter   stsc6 0MaritimeSecurityMonitoring.TypeToStringConverter  ttsc; 5MaritimeSecurityMonitoring.AlarmTypeToStringConverter 	 attsc< 6MaritimeSecurityMonitoring.AlarmTypeToContentConverter 	 attcc1 +MaritimeSecurityMonitoring.AISToIDConverter  atic3 -MaritimeSecurityMonitoring.RadarToIDConverter  rtic3 -MaritimeSecurityMonitoring.MergeToIDConverter  mtic6 0MaritimeSecurityMonitoring.ByteToStringConverter  btsc<	 6MaritimeSecurityMonitoring.SailStatusToStringConverter 	 sstsc8
 2MaritimeSecurityMonitoring.AlarmToEnabledConverter 	 atec 
 TargetButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName  CornerButton �� CornerRadius  CornerToggleButton8  2MaritimeSecurityMonitoring.ColumnViewportConverter  columnViewportConverter  columnHeight  verticalLineColor �� Color  horizontalLineColor1 �� EndPoint �� 
StartPoint � Color � Offset  horizontalLineColor2 J� SnapsToDevicePixels � ColumnDefinitions � RowDefinitions ��Name �� Columns �� Path �� RelativeSource! �� ColumnHeaderContainerStyle �� ColumnHeaderTemplate# �� ColumnHeaderTemplateSelector �� AllowsColumnReorder �� ColumnHeaderContextMenu �� ColumnHeaderToolTip  ��Name-  'System.Windows.Input.KeyboardNavigation!   DirectionalNavigation" �� CanContentScroll# �� Orientation$ j� TileMode% j� Stretch& j� ViewportUnits' j� Viewport( �� Source) �� 	Converter* !� Visual+ ��Name,, �� %ComputedHorizontalScrollBarVisibility- � Cursor. �� ScrollableWidth/ � Maximum0 � Minimum1 �� Orientation2 �� ViewportWidth3 �� ViewportSize4 � Value5 �� Mode*6 �� #ComputedVerticalScrollBarVisibility7 �� ScrollableHeight8 �� ViewportHeight9 �� ElementName��%3  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     &	
 2     &	 x    &	 �    '�� �    &	     &	     &	     &	 '    &	 �    (�� �    *'%GridView.GridViewScrollViewerStyleKey+)7  7                  	  
  �� " ��.���  � ��$ 17(���  � ��
 �������  � �� �� " ��.R��� $ bd��$��2q����	#FF007CC3���	#FF007CC3._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ bd�� � �� �	#FF6EB5DCP� 
 � {� .  . ��� $ bd�� � �� �	#FF6EB5DC�� " ��.���  � ��
 �������  � �� �� " ��.R��� $ bd��$��0q�$ 3�����	#FF5AC2F1._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ bd�� � �� �	#FFA3C5EEP� 
 � �� . . ��� $ bd�� � ��
 ������� " d�.���  � ��
 �������  � �� �� " d�.R��� $ bd��$��0q�$ 3�����	#FF5AC2F1._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ bd�� � �� �	#FFA3C5EEP� 
 �@d�	IsChecked$
 TrueY�. ��� $ bd�� � ��
 ������� " ��.���  � ��$ 30����  � ��$ 14(�  X�26Q��� $ 	#FFDCD8D8���� $ 0.494,0.081&�$ 0.494,1.083&�.��� $ #C4E1FF��$ 0Q�� $ 	#FFFBFBFB��$ 1Q��� $ 	0.5,0.229&�$ 0.482,0.938&�.��� $ #C4E1FF��$ 0Q�� $ 	#FFFBFBFB��$ 1Q��� " ��.���  � |� .  ��  � �� �� " ��.R��  . #��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+�]� #��z��.+��� |�.  $��Hidden=�$��Hidden=�$	��Top=�.���� $ viewHeaderRowPresenter��$��2,0,2,0q�# z  �� $" TemplatedParent.View.Columns� �� *TemplatedParent+ �� $5 /TemplatedParent.View.ColumnHeaderContainerStyle� �� *TemplatedParent+ �� $/ )TemplatedParent.View.ColumnHeaderTemplate� �� *TemplatedParent+ �� $7 1TemplatedParent.View.ColumnHeaderTemplateSelector� �� *TemplatedParent+ �� $. (TemplatedParent.View.AllowsColumnReorder� �� *TemplatedParent+ �� $2 ,TemplatedParent.View.ColumnHeaderContextMenu� �� *TemplatedParent+ �� $. (TemplatedParent.View.ColumnHeaderToolTip� �� *TemplatedParent+�� $!  PART_ScrollContentPresenter��# z #��z��$! Local=�#" z����� .+��� $��3,0,0,0q����� $" TemplatedParent.View.Columns� �� *TemplatedParent+���� .R��� $��	0 0 0.6 0q�#���  ���� $ ActualWidth����� .R��� $# 
Horizontal=���!� $
$ Tile=�$
% None=�$& Absolute=�' �� 8(   8)  * �� $��Center=�$��Center=�.+��� #���  $��Center=�#���  $��1���� #���  $��Center=�#���  $��1���� #��z���� $+ PART_HorizontalScrollBar��#y�z, $- Arrow��$��1��#/ z. $	0 0.0Q�$1 
Horizontal=�#3 z2 4 �� $ HorizontalOffset�$5 OneWay=� �� *TemplatedParent+�� $+ PART_VerticalScrollBar��#y�z6 $- Arrow��$��1��#/ z7 $	0 0.0Q�$1 Vertical=�#3 z8 4 �� $ VerticalOffset�$5 OneWay=� �� *TemplatedParent+]� $��1��$��1����.  ���� $ 
Background�$9 PART_VerticalScrollBar��.+��� #y�z6 $��1��
�������$
��Left=��� #y�z, $��1��
�������$	��Top=�.���� 
�������$��0 0 0 2q�
������ ._��  �� $��3* ��� $��* � �� $��5* ��� $
��1.3* �.+�� -   $��video��$��0��$��1�� �� $��* ��� $��* ��� $��* �.+�7  1System.Windows.Forms.Integration.WindowsFormsHost  -   $��0��$��2��:   Child.:    NVRCsharpDemo.mypanel  -   infraredRayPictureBox��"  System.Windows.Forms.Control;   Margin+  %System.Windows.Forms.PaddingConverter$; 0,0,0,0   $��1��$��0,1,0,0q�.:   -   followingPictureBox��$; 0,0,0,0   $��2��$��0,1,0,0q�.:   -   telephotoPictureBox��$; 0,0,0,0   -   <  Name$< 	formshost��$��0��.:   YimaWF.YimaEncCtrl  -   yimaEncCtrl��� $��1��$��0�� �� $��* ��� $��5* ��� $��4* �.+��� $��0��
������ 
�������$��0 0 2 0q�._��  �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��30��
�������$��15(�$��Center=�.��	目 标�� -	   = ��Name$= allbtn��$��1��#��[
 .��所 有 目 标�� -
   $= aisbtn��$��2��#��[
 .��A I S 目 标�� -   $= radarbtn��$��3��#��[
 .��雷 达 目 标�� -   $= mixbtn��$��4��#��[
 .��融 合 目 标�� -   $��mixListView��$��1�����#d9ebf6$��2 0 2 4q�$y�	Collapsed=����� ���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$5 OneWay=�> �� Triggers> P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FD? �� View? �� .P��� $��融合批号��@ �� Width$@ 80��A �� DisplayMemberBindingA �� *ID+�� $��子源个数��$@ 80��A �� *SrcNum+�� $��雷达1批号��$@ 90��A `� B `� 	Converter#B [ .1��� $ Source�#) [  �� $ RadarBatchNum��� $��雷达2批号��$@ 90��A `� #B [ .1��� $ Source�#) [  �� $ RadarBatchNum2��� $
��MMSI��$@ 90��A `� #B [ .1��� $ Source�#) [  �� $ MIMSI��� $��融合经度(°)��$@ 90��A �� *	Longitude+�� $��融合纬度(°)��$@ 90��A �� *
Latitude+�� $��国籍��$@ 50��A �� *Nationality+�� $��发现时间��$	@ 140��A �� *
UpdateTime+�� $��融合类型��$@ 80��A �� *
DataType+#) [ �� $��距离(米)��$@ 80��A �� *
Distance+�� $��航向角(°)��$@ 80��A �� *Course+�� $��船名��$@ 80��A �� *Name+�� $��呼号��$@ 80��A �� *
CallSign+�� $��最大吃水(米)��$@ 90��A �� *	MaxDeep+�� $��船载人数��$@ 80��A �� *
Capacity+�� $��	目的地��$@ 80��A �� *Destination+�� -   $��radarListView��$��1�����#d9ebf6$��2 0 2 4q�$y�	Collapsed=����� ���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$5 OneWay=�> P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FD? �� .P��� $��雷达1批号��$@ 90��A `� #B [ .1��� $ Source�#) [  �� $ RadarBatchNum��� $��雷达2批号��$@ 90��A `� #B [ .1��� $ Source�#) [  �� $ RadarBatchNum2��� $��距离(米)��$@ 80��A �� *
Distance+�� $��
经度(°)��$@ 80��A �� *	Longitude+�� $��
纬度(°)��$@ 80��A �� *
Latitude+�� $��航向角(°)��$@ 80��A �� *Course+�� $��真北方位��$@ 80��A �� *North+�� $��对地速度(节)��$@ 90��A �� *Speed+�� $��发现时间��$	@ 140��A �� *
UpdateTime+�� -   $��AISListView��$��1�����#d9ebf6$��2 0 2 4q�$y�	Collapsed=����� ���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$5 OneWay=�> P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FD? �� .P��� $
��MMSI��$@ 80��A �� *MIMSI+�� $��国籍��$@ 50��A �� *Nationality+�� $��
经度(°)��$@ 80��A �� *	Longitude+�� $��
纬度(°)��$@ 80��A �� *
Latitude+�� $��航向角(°)��$@ 80��A �� *Course+�� $��航行状态��$	@ 150��A `� #B [ .1��� $ Source�#) [  �� $ MIMSI��� $ 
SailStatus��� $��船名��$@ 80��A �� *Name+�� $��发现时间��$	@ 140��A �� *
UpdateTime+�� $	��IMO��$@ 80��A �� *IMO+�� $��呼号��$@ 80��A �� *
CallSign+�� $��对地速度(节)��$@ 90��A �� *Speed+�� $��最大吃水(米)��$@ 90��A �� *	MaxDeep+�� $��船载人数��$@ 80��A �� *
Capacity+�� $��	目的地��$@ 80��A �� *Destination+�� -   $��allListView��$��1�����#d9ebf6$��2 0 2 4q����� ���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$5 OneWay=�> P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FD? �� .P��� $��来源��$@ 50��A �� *Source+#) [  �� $��融合批号��$@ 80��A `� #B [ .1��� $ Source�#) [  �� $ ID��� $��雷达1批号��$@ 90��A `� #B [ .1��� $ Source�#) [  �� $ RadarBatchNum��� $��雷达2批号��$@ 90��A `� #B [ .1��� $ Source�#) [  �� $ RadarBatchNum2��� $
��MMSI��$@ 80��A `� #B [ .1��� $ Source�#) [  �� $ MIMSI��� $��
经度(°)��$@ 80��A �� *	Longitude+�� $��
纬度(°)��$@ 80��A �� *
Latitude+�� $��国籍��$@ 50��A �� *Nationality+�� $��航向角(°)��$@ 80��A �� *Course+�� $��敌我类型��$@ 80��A `� #B [ .1��� $ Source�#) [  �� $
 Type��� $��航行状态��$	@ 150��A `� #B [ .1��� $ Source�#) [  �� $ MIMSI��� $ 
SailStatus��� $��融合类型��$@ 80��A �� *
DataType+#) [ �� $��发现时间��$	@ 140��A �� *
UpdateTime+�� $��到达时间��$@ 80��A �� *
ArriveTime+�� $��子源个数��$@ 80��A �� *SrcNum+�� $��距离(米)��$@ 80��A �� *
Distance+�� $��真北方位(°)��$@ 90��A �� *North+�� $��对地速度(节)��$@ 90��A �� *Speed+�� $��船名��$@ 80��A �� *Name+�� $��呼号��$@ 80��A �� *
CallSign+�� $��最大吃水(米)��$@ 90��A �� *	MaxDeep+�� $��船载人数��$@ 80��A �� *
Capacity+�� $��	目的地��$@ 80��A �� *Destination+�� $	��IMO��$@ 80��A �� *IMO+�� -   $��warnListView��$��2�����#d9ebf6$��2 0 2 4q����� ���� " ��.���  � ��
 �  ����  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$5 TwoWay=�C �� UpdateSourceTrigger$C PropertyChanged=�> P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FD�� D �� BindingD �� $ 
AlarmCheck�E �� ValueE true.a���  � ��
 �   �? �� .P��� $��告警时间��$	@ 140��A �� *	AlarmTime+�� $
��MMSI��$@ 80��A `� #B [ .1��� $ Source�#) [  �� $ MIMSI��� $��告警类型��$@ 80��A �� *Action+#) [ �� $��告警区域��$@ 90��A �� *Alarm+#) [ �� $��国籍��$@ 50��A �� *Nationality+�� $��敌我类型��$@ 80��A `� #B [ .1��� $ Source�#) [  �� $
 Type��� $@ 50��F �� CellTemplateF �� .R��� -   $��确认��$��35��$��20��
�������{��� *
AlarmCheck+#) [	 ���� $ ID�� $��1��$��1��.+��� $��0q����	#FFC2E6FB$��0 0 0 4q�._��  �� $��* ��� $
��1.1* � �� $��* ��� $
��1.2* �.+�� $��0��$��0��.+��� $��2q����	#FF4AB8EC$ 8��$��10 8 3 1q�._��  �� $��* ��� $
��Auto ��� $��* �.+�� $��0��$��Center=�$��Center=�.+��� $��15(�$��Center=�变焦�� -   $��0q�
������ $��30��$��	14 0 12 0q�.���� $��Image\Plus.png���� -   $��0q�
������ $��30��.���� $��Image\Minus.png���� $��1��$��2��$��1q����	#FF8AD1F7$
��10 0q�� $��2��$��Center=�$��Center=�.+��� $��15(�$��Center=�聚焦�� -   $��0q�
������ $��30��$��	14 0 12 0q�.���� $��Image\Plus.png���� -   $��0q�
������ $��30��.���� $��Image\Minus.png��� ���	#FFC2E6FB$	��Top=�$
��Left=�$��17 2 0 0q�.+��� ���	#FF4AB8EC$��Center=�$��1 0 0 0q�长焦�� $��40��$��2q����	#FF4AB8EC$ 2��$��3 0 2 0q�._��� -   $��TcAngle��$��10(�G �� 
IsReadOnlyG . $��0q�
������ $��Center=�$��Center=�.��45� $��0��$��1��.+��� $��2q����	#FF4AB8EC$ 8��$��5 8 10 1q�._��  �� $��* ��� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�� $��0��$��Center=�$��Center=�.+��� $��15(�$��Center=�变焦�� -   $��0q�
������ $��30��$��	14 0 12 0q�.���� $��Image\Plus.png���� -   $��0q�
������ $��30��.���� $��Image\Minus.png���� $��1��$��2��$��1q����	#FF8AD1F7$
��10 0q�� $��2��$��Center=�$��Center=�.+��� $��15(�$��Center=�聚焦�� -   $��0q�
������ $��30��$��	14 0 12 0q�.���� $��Image\Plus.png���� -   $��0q�
������ $��30��.���� $��Image\Minus.png��d� -   $	��red��$��0��$��1��#��[ $��20��$��0 3 10 3q�.���� 开�� 关�� -   $��2��$��1��#��[ $��20��$��0 3 10 3q�.���� 矫�� 正� ���	#FFC2E6FB$	��Top=�$
��Left=�$��12 2 0 0q�.+��� ���	#FF4AB8EC$��Center=�$��1 0 0 0q�红外�� $��40��$��2q����	#FF4AB8EC$ 2��$��3 0 2 0q�._��� -   $��redAngle��$��10(�G . $��0q�
������ $��Center=�$��Center=�.��45� $��1��$��0��.+��� $��2q����	#FF4AB8EC$ 8��$��10 5 3 6q�._��  �� $��* ��� $��3* �.+�� $��0��$��Bottom=�$��Center=�.+��� $��10(�$��Center=�方位�� $��38��$��2q����	#FF4AB8EC$ 2��$��2 0 8 0q�._��� -   $��horizontalAngle��$��10(�G . $��0q�
������ $��Center=�$��Center=�.��	45°45′�� $��10(�$��Center=�俯仰�� $��38��$��2q����	#FF4AB8EC$ 2��$��2 0 0 0q�._��� -    $��verticalAngle��$��10(�G . $��0q�
������ $��Center=�$��Center=�.��	45°45′� $��1��H �� Stretch$
H Fill=����	#FFAADEFBI � Points)I �   @KL @KL ��� @KL @KL ��� $
��15 5q�� $��1��$
��15 5q� �� $��* ��� $��* ��� $��* � �� $��* ��� $
��0.6* ��� $��* ��� $
��0.6* ��� $��* �.+��� -!   $��0��$��2��$��20��$��16������ " ��.R�� .+�� J �Name$J ButtonPolygon��$
H Fill=�I �   ��� @KL ��� ��� ���� $	 0,1&�$	 1,1&�.��� $ 	#FF5AC2F1��$	 0.5Q�� $ 	#FF4AB8EC��$	 0.5Q�	 P� 
 �@J�IsMouseOver . . ��� $ ButtonPolygon�� � �� �	#FFA3C5EEP� 
 � �� . . ��� $ ButtonPolygon�� � ��
 ������� -"   $��1��$��0��$��16��$��20��$��5 0 -5 0q����� " ��.R�� .+�� $J ButtonPolygon��$
H Fill=�I �   @KL ��� ��� ��� ���� $ 	#FF5AC2F1��	 P� 
 �@J�IsMouseOver . . ��� $ ButtonPolygon�� � �� �	#FFA3C5EEP� 
 � �� . . ��� $ ButtonPolygon�� � ��
 ������� -#   $��1��$��4��$��16��$��20��$��-5 0 5 0q����� " ��.R�� .+�� $J ButtonPolygon��$
H Fill=�I �   ��� ��� @KL ���� $ 	#FF4AB8EC��	 P� 
 �@J�IsMouseOver . . ��� $ ButtonPolygon�� � �� �	#FFA3C5EEP� 
 � �� . . ��� $ ButtonPolygon�� � ��
 ������� -$   $��2��$��2��$��20��$��16������ " ��.R�� .+�� $J ButtonPolygon��$
H Fill=�I �   ��� @KL ��� ���� $	 0,1&�$	 1,1&�.��� $ 	#FF5AC2F1��$	 0.5Q�� $ 	#FF4AB8EC��$	 0.5Q�	 P� 
 �@J�IsMouseOver . . ��� $ ButtonPolygon�� � �� �	#FFA3C5EEP� 
 � �� . . ��� $ ButtonPolygon�� � ��
 ������� $��1��$��2��$��20��$��16������ " ��.R��� $ bd��$��0q�$ 3������ $	 0,1&�$	 1,1&�.��� $ 	#FF5AC2F1��$	 0.5Q�� $ 	#FF4AB8EC��$	 0.5Q�	 P� 
 �@J�IsMouseOver . . ��� $ bd�� � �� �	#FFA3C5EEP� 
 � �� . . ��� $ bd�� � ��
 ������� ���	#FFC2E6FB���	#FF4AB8EC$
��Left=�$	��Top=�$��18,0,0,0q�云台控制� $��1��$��1��$��5 5 10 6q� �� $��* ��� $��* ��� $��0.75* �.+��� $��0��$��2q����	#FF4AB8EC$ 8��$��0 0 0 2q�._��  �� $��* ��� $��* �.+�d� -%   $��driveSwitchButton��$��0��#��[ $��14(�$��22��$��60��$��Right=�$��0 0 11 0q�.��驱动d� -&   $
��scan��$��1��#��[ $��14(�$��22��$��60��$
��Left=�$��11 0 0 0q�.��扇扫�� $��1��$��2q����	#FF4AB8EC$ 8��$��0 2 0 0q�._��  �� $��* ��� $��* �.+��� -'   $��0��#��[ $��14(�$��22��$��60��$��Right=�$��0 0 11 0q�.��重启�� -(   $��1��#��[ $��14(�$��22��$��60��$
��Left=�$��11 0 0 0q�.��关机d� 2  ,System.Windows.Markup.XmlAttributePropertiesK  XmlSpaceK preserve-)   $��contral��$��2��#��[ $��14(�$��1 5 1 1q�.��	主   控