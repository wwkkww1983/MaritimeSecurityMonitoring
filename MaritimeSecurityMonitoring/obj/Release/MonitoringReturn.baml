   M S B A M L   `   `   `  ���� H  DNVRCsharpDemo, Version=2.0.1.1, Culture=neutral, PublicKeyToken=nullD2clr-namespace:NVRCsharpDemo;assembly=NVRCsharpDemoNVRCsharpDemo  ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms A =YimaWF, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null/$clr-namespace:YimaWF;assembly=YimaWFYimaWF O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem U QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring 1   +MaritimeSecurityMonitoring.MonitoringReturn   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	    @d2http://schemas.microsoft.com/expression/blend/2008 	    BDVR2clr-namespace:NVRCsharpDemo;assembly=NVRCsharpDemo 	    _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration 	    Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms 	    3ym$clr-namespace:YimaWF;assembly=YimaWF 	    6clr&clr-namespace:System;assembly=mscorlib 	    :local(clr-namespace:MaritimeSecurityMonitoring 	    -     N� Title$  MonitoringX�� N� ShowsNavigationUI .   N� 	KeepAlive .  � 	Resources 8 2MaritimeSecurityMonitoring.SourceToStringConverter   stsc6 0MaritimeSecurityMonitoring.TypeToStringConverter  ttsc; 5MaritimeSecurityMonitoring.AlarmTypeToStringConverter 	 attsc< 6MaritimeSecurityMonitoring.AlarmTypeToContentConverter 	 attcc1 +MaritimeSecurityMonitoring.AISToIDConverter  atic3 -MaritimeSecurityMonitoring.RadarToIDConverter  rtic3 -MaritimeSecurityMonitoring.MergeToIDConverter  mtic6 0MaritimeSecurityMonitoring.ByteToStringConverter  btsc<	 6MaritimeSecurityMonitoring.SailStatusToStringConverter 	 sstsc8
 2MaritimeSecurityMonitoring.AlarmToEnabledConverter 	 atec 
 TargetButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName  OneCornerButton �� CornerRadius  NoCornerButton  CornerButton  UpTriButton �Name �� Stretch � Points �� Color  BottomTriButton8  2MaritimeSecurityMonitoring.ColumnViewportConverter  columnViewportConverter  columnHeight  verticalLineColor  horizontalLineColor1 �� EndPoint �� 
StartPoint � Color � Offset  horizontalLineColor2 J� SnapsToDevicePixels � ColumnDefinitions � RowDefinitions ��Name �� Columns �� Path �� RelativeSource! �� ColumnHeaderContainerStyle �� ColumnHeaderTemplate# �� ColumnHeaderTemplateSelector  �� AllowsColumnReorder! �� ColumnHeaderContextMenu" �� ColumnHeaderToolTip# ��Name-  'System.Windows.Input.KeyboardNavigation$   DirectionalNavigation% �� CanContentScroll& �� Orientation' j� TileMode( j� Stretch) j� ViewportUnits* j� Viewport+ �� Source, �� 	Converter- !� Visual. ��Name,/ �� %ComputedHorizontalScrollBarVisibility0 � Cursor1 �� ScrollableWidth2 � Maximum3 � Minimum4 �� Orientation5 �� ViewportWidth6 �� ViewportSize7 � Value8 �� Mode*9 �� #ComputedVerticalScrollBarVisibility: �� ScrollableHeight; �� ViewportHeight< �� ElementName��%r  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -     &	
 2     &	 x    &	 �    &	 �    &	 �    &	 �    '�� �    &	 "    &	 '    &	 3    &	 H    &	 �    (��     *'%GridView.GridViewScrollViewerStyleKey+)7  7                  	  
  �� " ��.���  � ��$ 17(���  � ��
 �������  � �� �� " ��.R��� $ bd��$��2q����	#FF007CC3���	#FF007CC3._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ bd�� � �� �	#FF6EB5DCP� 
 � {� .  . ��� $ bd�� � �� �	#FF6EB5DC�� " ��.���  � �� �� " ��.R��� $	 bd1��$��0 0 2 2q����	#FF007CC3$ 3 0 0 0��._��� #��z��$��Center=�$��Center=�$
��10 5q�	 P� 
 �@J�IsMouseOver . . ��� $	 bd1�� � �� �	#FF6EB5DCP� 
 � {� .  . ��� $	 bd1�� � �� �	#FF6EB5DC�� " ��.���  � �� �� " ��.R��� $	 bd2��$��0 0 2 2q����	#FF007CC3._��� #��z��$��Center=�$��Center=�$
��10 5q�	 P� 
 �@J�IsMouseOver . . ��� $	 bd2�� � �� �	#FF6EB5DCP� 
 � {� .  . ��� $	 bd2�� � �� �	#FF6EB5DC�� " ��.���  � ��
 �������  � �� �� " ��.R��� $ bd��$��0q�$ 3�����	#FF5AC2F1._��� #��z��$��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ bd�� � �� �	#FFA3C5EEP� 
 � �� . . ��� $ bd�� � ��
 ������� " ��.R�� .+�� $ ButtonPolygon��$
 Fill=� �   ��� @KL ��� ��� ���� $ 	#FF007CC3��	 P� 
 �@J�IsMouseOver . . ��� $ ButtonPolygon�� � ��
 �����P� 
 � �� . . ��� $ ButtonPolygon�� � ��
 �   ��� " ��.R�� .+�� $ ButtonPolygon��$
 Fill=� �   ��� @KL ��� ���� $ 	#FF007CC3��	 P� 
 �@J�IsMouseOver . . ��� $ ButtonPolygon�� � ��
 �����P� 
 � �� . . ��� $ ButtonPolygon�� � ��
 �   ��� " ��.���  � ��$ 30����  � ��$ 14(�  X�26Q��� $ 	#FFDCD8D8���� $ 0.494,0.081&�$ 0.494,1.083&�.��� $ #C4E1FF��$ 0Q�� $ 	#FFFBFBFB��$ 1Q��� $ 	0.5,0.229&�$ 0.482,0.938&�.��� $ #C4E1FF��$ 0Q�� $ 	#FFFBFBFB��$ 1Q��� " ��.���  � |� .  ��  � �� �� " ��.R��  . #��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+�]� #��z��.+��� |�.  $��Hidden=�$��Hidden=�$	��Top=�.���� $ viewHeaderRowPresenter��$��2,0,2,0q�# z  �� $" TemplatedParent.View.Columns� �� *TemplatedParent+ �� $5 /TemplatedParent.View.ColumnHeaderContainerStyle� �� *TemplatedParent+ �� $/ )TemplatedParent.View.ColumnHeaderTemplate� �� *TemplatedParent+ �� $7 1TemplatedParent.View.ColumnHeaderTemplateSelector� �� *TemplatedParent+  �� $. (TemplatedParent.View.AllowsColumnReorder� �� *TemplatedParent+! �� $2 ,TemplatedParent.View.ColumnHeaderContextMenu� �� *TemplatedParent+" �� $. (TemplatedParent.View.ColumnHeaderToolTip� �� *TemplatedParent+�� $!# PART_ScrollContentPresenter��# z #��z��$$ Local=�#% z����� .+��� $��3,0,0,0q����� $" TemplatedParent.View.Columns� �� *TemplatedParent+���� .R��� $��	0 0 0.6 0q�#���  ���� $ ActualWidth����� .R��� $& 
Horizontal=���!� $
' Tile=�$
( None=�$) Absolute=�* �� 8+   8,  - �� $��Center=�$��Center=�.+��� #���  $��Center=�#���  $��1���� #���  $��Center=�#���  $��1���� #��z���� $. PART_HorizontalScrollBar��#y�z/ $0 Arrow��$��1��#2 z1 $	3 0.0Q�$4 
Horizontal=�#6 z5 7 �� $ HorizontalOffset�$8 OneWay=� �� *TemplatedParent+�� $. PART_VerticalScrollBar��#y�z9 $0 Arrow��$��1��#2 z: $	3 0.0Q�$4 Vertical=�#6 z; 7 �� $ VerticalOffset�$8 OneWay=� �� *TemplatedParent+]� $��1��$��1����.  ���� $ 
Background�$< PART_VerticalScrollBar��.+��� #y�z9 $��1��
�������$
��Left=��� #y�z/ $��1��
�������$	��Top=�.���� 
�������$��0 0 0 2q�
������ ._��  �� $��3* ��� $��* � �� $��5* �.+�7  1System.Windows.Forms.Integration.WindowsFormsHost  -   =  Name$= 	formshost��$��0��>   Child.>   YimaWF.YimaEncCtrl  -   yimaEncCtrl��� $��1��$��0�� �� $��* ��� $
��5.8* ��� $
��3.2* �.+��� $��0��
������ 
�������$��0 0 2 0q�._��  �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��30��
�������$��15(�$��Center=�.��	目 标�� -   ? ��Name$? allbtn��$��1��#��[
 .��所 有 目 标�� -   $? aisbtn��$��2��#��[
 .��A I S 目 标�� -   $? radarbtn��$��3��#��[
 .��雷 达 目 标�� -   $? mixbtn��$��4��#��[
 .��融 合 目 标�� -   $��mixListView��$��1�����#d9ebf6$��2 0 2 4q�$y�	Collapsed=����� ���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$8 OneWay=�@ �� Triggers@ P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FDA �� ViewA �� .P��� $��融合批号��B �� Width$B 80��C �� DisplayMemberBindingC �� *ID+�� $��子源个数��$B 80��C �� *SrcNum+�� $��雷达1批号��$B 90��C `� D `� 	Converter#D [ .1��� $ Source�#, [  �� $ RadarBatchNum��� $��雷达2批号��$B 90��C `� #D [ .1��� $ Source�#, [  �� $ RadarBatchNum2��� $
��MMSI��$B 90��C `� #D [ .1��� $ Source�#, [  �� $ MIMSI��� $��融合经度(°)��$B 90��C �� *	Longitude+�� $��融合纬度(°)��$B 90��C �� *
Latitude+�� $��国籍��$B 50��C �� *Nationality+�� $��发现时间��$	B 140��C �� *
UpdateTime+�� $��融合类型��$B 80��C �� *
DataType+#, [ �� $��距离(米)��$B 80��C �� *
Distance+�� $��航向角(°)��$B 80��C �� *Course+�� $��船名��$B 80��C �� *Name+�� $��呼号��$B 80��C �� *
CallSign+�� $��最大吃水(米)��$B 90��C �� *	MaxDeep+�� $��船载人数��$B 80��C �� *
Capacity+�� $��	目的地��$B 80��C �� *Destination+�� -	   $��radarListView��$��1�����#d9ebf6$��2 0 2 4q�$y�	Collapsed=����� ���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$8 OneWay=�@ P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FDA �� .P��� $��雷达1批号��$B 90��C `� #D [ .1��� $ Source�#, [  �� $ RadarBatchNum��� $��雷达2批号��$B 90��C `� #D [ .1��� $ Source�#, [  �� $ RadarBatchNum2��� $��距离(米)��$B 80��C �� *
Distance+�� $��
经度(°)��$B 80��C �� *	Longitude+�� $��
纬度(°)��$B 80��C �� *
Latitude+�� $��航向角(°)��$B 80��C �� *Course+�� $��真北方位��$B 80��C �� *North+�� $��对地速度(节)��$B 90��C �� *Speed+�� $��发现时间��$	B 140��C �� *
UpdateTime+�� -
   $��AISListView��$��1�����#d9ebf6$��2 0 2 4q�$y�	Collapsed=����� ���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$8 OneWay=�@ P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FDA �� .P��� $
��MMSI��$B 80��C �� *MIMSI+�� $��国籍��$B 50��C �� *Nationality+�� $��
经度(°)��$B 80��C �� *	Longitude+�� $��
纬度(°)��$B 80��C �� *
Latitude+�� $��航向角(°)��$B 80��C �� *Course+�� $��航行状态��$	B 150��C `� #D [ .1��� $ Source�#, [  �� $ MIMSI��� $ 
SailStatus��� $��船名��$B 80��C �� *Name+�� $��发现时间��$	B 140��C �� *
UpdateTime+�� $	��IMO��$B 80��C �� *IMO+�� $��呼号��$B 80��C �� *
CallSign+�� $��对地速度(节)��$B 90��C �� *Speed+�� $��最大吃水(米)��$B 90��C �� *	MaxDeep+�� $��船载人数��$B 80��C �� *
Capacity+�� $��	目的地��$B 80��C �� *Destination+�� -   $��allListView��$��1�����#d9ebf6$��2 0 2 4q����� ���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$8 OneWay=�@ P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FDA �� .P��� $��来源��$B 50��C �� *Source+#, [  �� $��融合批号��$B 80��C `� #D [ .1��� $ Source�#, [  �� $ ID��� $��雷达1批号��$B 90��C `� #D [ .1��� $ Source�#, [  �� $ RadarBatchNum��� $��雷达2批号��$B 90��C `� #D [ .1��� $ Source�#, [  �� $ RadarBatchNum2��� $
��MMSI��$B 80��C `� #D [ .1��� $ Source�#, [  �� $ MIMSI��� $��
经度(°)��$B 80��C �� *	Longitude+�� $��
纬度(°)��$B 80��C �� *
Latitude+�� $��国籍��$B 50��C �� *Nationality+�� $��航向角(°)��$B 80��C �� *Course+�� $��敌我类型��$B 80��C `� #D [ .1��� $ Source�#, [  �� $
 Type��� $��航行状态��$	B 150��C `� #D [ .1��� $ Source�#, [  �� $ MIMSI��� $ 
SailStatus��� $��融合类型��$B 80��C �� *
DataType+#, [ �� $��发现时间��$	B 140��C �� *
UpdateTime+�� $��到达时间��$B 80��C �� *
ArriveTime+�� $��子源个数��$B 80��C �� *SrcNum+�� $��距离(米)��$B 80��C �� *
Distance+�� $��真北方位(°)��$B 90��C �� *North+�� $��对地速度(节)��$B 90��C �� *Speed+�� $��船名��$B 80��C �� *Name+�� $��呼号��$B 80��C �� *
CallSign+�� $��最大吃水(米)��$B 90��C �� *	MaxDeep+�� $��船载人数��$B 80��C �� *
Capacity+�� $��	目的地��$B 80��C �� *Destination+�� $	��IMO��$B 80��C �� *IMO+�� -   $��warnListView��$��2�����#d9ebf6$��2 0 2 4q����� ���� " ��.���  � ��
 �  ����  � ��$ Center=���  � ��$ Center=���  � ��$ 25����  �@��
IsSelected �� *
IsSelected+$8 TwoWay=�E �� UpdateSourceTrigger$E PropertyChanged=�@ P� 
 �@��
IsSelected . . ���  � �� �	#FF007CC3��  � �� �	#FF9BC8FD�� F �� BindingF �� $ 
AlarmCheck�G �� ValueG true.a���  � ��
 �   �A �� .P��� $��告警时间��$	B 140��C �� *	AlarmTime+�� $
��MMSI��$B 80��C `� #D [ .1��� $ Source�#, [  �� $ MIMSI��� $��告警类型��$B 80��C �� *Action+#, [ �� $��告警区域��$B 90��C �� *Alarm+#, [ �� $��国籍��$B 50��C �� *Nationality+�� $��敌我类型��$B 80��C `� #D [ .1��� $ Source�#, [  �� $
 Type��� $B 50��H �� CellTemplateH �� .R��� -   $��确认��$��35��$��20��
�������{��� *
AlarmCheck+#, [	 ���� $ ID�