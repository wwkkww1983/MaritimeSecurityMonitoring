   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  *    $MaritimeSecurityMonitoring.DataQuery   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6m(clr-namespace:MaritimeSecurityMonitoring     -     N� Title$  	DataQuery��   
CommonPage#��[   � 	Resources  �� 
TargetType �� Property �� Value  CornerButton �� 
TargetType ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName  TextBoxErrorTemp �� Triggers �� ElementName �� Path��%E  '	�       '�� �     '�� �     &	     &	 �    �� " 	�.���  � �� �	#FFA3C5EE��  � �� �#d9ebf6��  � ��$ 14(���  � ��$
 Left=���  � ��$ Center=��� " ��.���  � ��$ Center=���  � ��$ 14(��� " ��.���  � ��
 ���� ��  � ��$ 15(��� " ��.R��� $ bd��$��0q�$ 5��
������ ._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � ��
 �����P� 	 � ��
 . . ��� $ bd�� � ��
 ������� " �� P� 	 �@=�HasError
 . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� $��Bottom=�
���  ��$��14(�$
��Bold"�$��Center=����� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��2q�$��53��._��� $��	MyAdorner��.��� $��
20 15 20 0q� � RowDefinitions �� $��60 ��� $	��140 ��� $��* ��� $
��Auto �.+��� $��0��  CommonGroupBox#��[ $��起止时间��.���� .+�/   )MaritimeSecurityMonitoring.DateTimePicker  -     Name$ 	StartTime��   Title$ 开始时间：��$	��280��$��30��
 �� Top$ 14�� �� Left$	 200���� $��28��$��2��$��1q����	#FFA3C5EE$ 29��$	 520��  -   $ EndTime��$ 结束时间：��$	��280��$��30��$ 14��$	 590���� $��1��#��[ $��数据选择��$��0 15 0 0q�.���  �� $��* ��� $��* �.+��� $��0��$��22��$
��Left=�$	��Top=�$��190 10q�$��Image\SituationData.png���� $��0��$��16(�$
��Left=�$	��Top=�$��220 10q�态势数据� $��0��$��0 30 0 0q�.+�	� -   $	��AIS��$��
250 10 0 0q�.��AIS	� -   $��radar��$��
120 10 0 0q�.��雷达	� -   $
��fuse��$��
120 10 0 0q�.��融合�� $��1��$��22��$
��Left=�$	��Top=�$��193 3q�$��Image\LogData.png���� $��1��$��16(�$
��Left=�$	��Top=�$��220 3q�日志数据� $��1��$��0 23 0 0q�.+�	� -   $��login��$��
250 10 0 0q�.��登录日志	� -   $��	operation��$��	86 10 0 0q�.��界面操作日志	� -	   $��alarm��$��	64 10 0 0q�.��报警日志	� -
   $��device��$��	86 10 0 0q�.��设备故障日志�� $��2��  CommonBorder#��[ $��0 8 0 0q�._�� -    �Name$ bd��$
��10,0q� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��1.5* ��� $��* ��� $��* ��� $��* ��� $��* �.+�� -   $ column1��$��0��� -   $ column2��$��9���� -   $��AISList��$��14��
������ $��0q�$y�	Collapsed=����� $ ActualWidth�$ bd������  �� View ��  �� AllowsColumnReorder . .P��� $��船名�� �� DisplayMemberBinding �� *
boatName+ �� Width �� $ column1��$ ActualWidth��� $	��IMO�� �� *IMO+ �� $ column1��$ ActualWidth��� $
��MMSI�� �� *MMSI+ �� $ column1��$ ActualWidth��� $��呼号�� �� *call+ �� $ column1��$ ActualWidth��� $��国籍�� �� *	country+ �� $ column1��$ ActualWidth��� $��
经度(°)�� �� *	longitude+ �� $ column1��$ ActualWidth��� $��
纬度(°)�� �� *
latitude+ �� $ column1��$ ActualWidth��� $��航向角(°)�� �� *angle+ �� $ column1��$ ActualWidth��� $��对地速度（节）�� �� *speed+ �� $ column1��$ ActualWidth��� $��发现时间�� �� *time+ �� $ column2��$ ActualWidth��� $��航行状态�� �� *
trackState+ �� $ column1��$ ActualWidth��� $��最大吃水（米）�� �� *high+ �� $ column1��$ ActualWidth��� $��船载人数�� �� *people+ �� $ column1��$ ActualWidth��� $��	目的地�� �� *
destance+ �� $ column1��$ ActualWidth��� -   $��	radarList��$��14��
������ $��0q�$y�	Collapsed=����� $ ActualWidth�$ bd������  ��  . .P��� $��雷达编号�� �� *	radarID+ �� $ column1��$ ActualWidth��� $��批号�� �� *number+ �� $ column1��$ ActualWidth��� $��距离(米)�� �� *
distance+ �� $ column1��$ ActualWidth��� $��
经度(°)�� �� *	longitude+ �� $ column1��$ ActualWidth��� $��
纬度(°)�� �� *
latitude+ �� $ column1��$ ActualWidth��� $��航向角(°)�� �� *angle+ �� $ column1��$ ActualWidth��� $��真北方位�� �� *north+ �� $ column1��$ ActualWidth��� $��対地速度（节）�� �� *speed+ �� $ column1��$ ActualWidth��� $��发现时间�� �� *time+ �� $ column2��$ ActualWidth��� -   $��fuseList��$��14��
������ $��0q�$y�	Collapsed=����� $ ActualWidth�$ bd������  ��  . .P��� $��融合批号�� �� *number+ �� $ column1��$ ActualWidth��� $��发现时间�� �� *time+ �� $ column2��$ ActualWidth��� $��融合类型�� �� *type+ �� $ column1��$ ActualWidth��� $��子源个数�� �� *
dataNumber+ �� $ column1��$ ActualWidth��� $��融合经度(°)�� �� *	longitude+ �� $ column1��$ ActualWidth��� $��融合纬度(°)�� �� *
latitude+ �� $ column1��$ ActualWidth��� $��航向角(°)�� �� *angle+ �� $ column1��$ ActualWidth��� $��船名�� �� *name+ �� $ column1��$ ActualWidth��� $��呼号�� �� *call+ �� $ column1��$ ActualWidth��� $��国籍�� �� *	country+ �� $ column1��$ ActualWidth��� $��敌我属性�� �� *Atrrbi+ �� $ column1��$ ActualWidth��� $��最大吃水（米）�� �� *high+ �� $ column1��$ ActualWidth��� $��船载人数�� �� *people+ �� $ column1��$ ActualWidth��� $
��MMSI�� �� *IMO+ �� $ column1��$ ActualWidth��� $��雷达1批号�� �� *radar_batch_id+ �� $ column1��$ ActualWidth��� $��雷达2批号�� �� *radar_batch_id2+ �� $ column1��$ ActualWidth��� -   $��userLoginList��$��14��
������ $��0q�$y�	Collapsed=����� $ ActualWidth�$ bd������  ��  . .P��� $��日志编号�� �� *	logNumber+ �� $ column1��$ ActualWidth��� $��	用户名�� �� *
userName+ �� $ column1��$ ActualWidth��� $��	操作名�� �� *	operate+ �� $ column1��$ ActualWidth��� $��操作时间�� �� *time+ �� $ column2��$ ActualWidth��� $��操作结果�� �� *result+ �� $ column1��$ ActualWidth��� $��备注信息�� �� *other+ �� $ column1��$ ActualWidth��� $��计算机IP�� �� *ip+ �� $ column1��$ ActualWidth��� $��日志类型�� �� *type+ �� $ column1��$ ActualWidth��� -   $��operateList��$��14��
������ $��0q�$y�	Collapsed=����� $ ActualWidth�$ bd������  ��  . .P��� $��日志编号�� �� *	logNumber+ �� $ column1��$ ActualWidth��� $��	用户名�� �� *
userName+ �� $ column1��$ ActualWidth��� $��	操作名�� �� *	operate+ �� $ column1��$ ActualWidth��� $��操作时间�� �� *time+ �� $ column2��$ ActualWidth��� $��操作结果�� �� *result+ �� $ column1��$ ActualWidth��� $��备注信息�� �� *other+ �� $ column1��$ ActualWidth��� $��计算机IP�� �� *ip+ �� $ column1��$ ActualWidth��� $��日志类型�� �� *type+ �� $ column1��$ ActualWidth��� -   $��	alarmList��$��14��
������ $��0q�$y�	Collapsed=����� $ ActualWidth�$ bd������  ��  . .P��� $��告警编号�� �� *DisplayNumber+ �� $ column1��$ ActualWidth��� $��告警区域�� �� *alarmNumber+ �� $ column2��$ ActualWidth��� $��告警时间�� �� *time+ �� $ column2��$ ActualWidth��� $��雷达1批号�� �� *radarNumber+ �� $ column1��$ ActualWidth��� $��雷达2批号�� �� *radarNumber2+ �� $ column1��$ ActualWidth��� $
��MMSI�� �� *IMO+ �� $ column1��$ ActualWidth��� $��告警类型�� �� *alarmString+ �� $ column1��$ ActualWidth��� $��国籍�� �� *	country+ �� $ column1��$ ActualWidth��� $��敌我属性�� �� *Atrrib+ �� $ column1��$ ActualWidth��� -   $��
deviceList��$��14��
������ $��0q�$y�	Collapsed=����� $ ActualWidth�$ bd������  ��  . .P��� $��日志编号�� �� *number+ �� $ column1��$ ActualWidth��� $��设备IP�� �� *ip+ �� $ column1��$ ActualWidth��� $��设备名称�� �� *device+ �� $ column1��$ ActualWidth��� $��设备联网状态�� �� *networkState+ �� $ column1��$ ActualWidth��� $��设备工作状态�� �� *	workState+ �� $ column1��$ ActualWidth��� $��时间�� �� *time+ �� $ column2��$ ActualWidth��� $��备注�� �� *other+ �� $ column1��$ ActualWidth�� $��3�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��$��30��$	��400��$��0 8 0 10q�$��1q����	#FFA3C5EE$ 6��._�� $��6�� �� $��* ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� -   $��0��#��[ $��16(�.��	首 页�� $��1��$��1��$��20��$��1q����	#FFA3C5EE�� -   $��2��#��[ $��16(�.��	上一页�� $��3��$��1��$��20��$��1q����	#FFA3C5EE�� -   $��4��#��[ $��16(�.��	下一页�� $��5��$��1��$��20��$��1q����	#FFA3C5EE�� -   $��6��#��[ $��16(�.��	尾 页� $��2��$��Center=�$��	20 8 0 10q�.+��� -   $��20��$��20��
������ $��0q�.���� $��Image\PageSearch.png���� $��14(�$��Center=�$��5 0 0 0q�到�� -    ��Name$ 
pageNumber��#��[ $��20��$��50��$��14(�
������ $��0 0 0 1q����	#FFA3C5EE$��Center=�$��5 0 0 0q�.������ $ number� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� ValidationRules ;   5MaritimeSecurityMonitoring.NumberValidationRuleForInt  -   
numberRule��
   Max$ 1��
    Min$  1��.���� -   $��currentPage��$��14(�$��Center=�$��5 0 0 0q�1�� $��14(�$��Center=�$��5 0 0 0q�/�� -   $��
totalPages��$��14(�$��Center=�$��5 0 0 0q�1�� $��14(�$��Center=�$��5 0 0 0q�页