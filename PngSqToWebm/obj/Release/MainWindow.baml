   M S B A M L   `   `   `  ���� F  BPngSqToWebm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PngSqToWebmPngSqToWebm      PngSqToWebm.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:PngSqToWebm     H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;controls,http://metro.mahapps.com/winfx/xaml/controls    � Title$%  PNG 시퀀스 -> Webm 변환기��$��360         ��$	��800�� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType �� Property �� Value   RadioButtonFocusVisual �� 
TargetType ��Name ��Name'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value R� KeyTime"  System.Windows.Media.Brushes   White R� Value��%�  '	�       �� " 	�
BlockRadio��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�FocusVisualStyle# �   ��  � �� �� " 	�.R��� ._�� .+��� $
 Back��
��������� $ Border��
���   �$��0���� $ Label��
���   �.���� $	��5,0q�$��Center=�$��Center=���. 	   CommonStates��.
   
Normal��  	MouseOver��. �� .��U� $ (Shape.StrokeThickness)�$ Border��.\�  $ 0��$ 2Q�  Pressed��. �� .���� $* $(Shape.Fill).(SolidColorBrush.Color)�$
 Back��.g�  $ 0��$ Black��T� $ (Control.Foreground)�$ Label��..�i� $ 0��# Z   CheckStates��.
   Checked��. �� .���� $* $(Shape.Fill).(SolidColorBrush.Color)�$
 Back��.g�  $ 0��$ Black��T� $ (Control.Foreground)�$ Label��..�i� $ 0��# Z   	Unchecked��  Indeterminate��.��� -    �Name$ 	Container��.+��� -    ��Name$ SqLabel��$��시퀀스 파일��$
��Left=�$��	10,31,0,0q�$	��Top=��� -    ��Name$ OpenPath��$��23��$��10,62,130,0q� �� TextWrapping$ NoWrap=�$	��Top=� �� 
IsReadOnly . �� -    ��Name$ 
OpenButton��$��열 기��$��Right=�$��	0,62,10,0q�$	��Top=�$	��117��$��26���� -    ��Name$ 
SqNumPanel��$��Stretch=�$��25��$��
10,90,10,0q�$	��Top=� �� Orientation$ 
Horizontal=����	#FFF2F2F2�� $
��Left=�$��
10,120,0,0q�$��NoWrap=�$>��8시퀀스 번호가 되는 부분을 선택해 주세요��$	��Top=�$	��650��$��Oblique$��� $��저장 경로��$
��Left=�$��
10,197,0,0q�$	��Top=��� -   $ SavePath��$��23��$��10,228,130,0q�$ NoWrap=�$	��Top=� . �� -   $ 
SaveButton��$��저 장��$��Right=�$��
0,228,10,0q�$	��Top=�$	��117��$��26��o� $��26��$	��Top=�$	��792�����	#FFE4E4E4$��0,0,0,1q�.@�m� $��설정��.@�m� -    m�Name$ 
FFmpegMenu��$��ffmpeg 경로 지정��� $��
10,0,10,10q�$��Bottom=�$��30�� � ColumnDefinitions �� $
��0.2* ��� $
��0.2* ��� $
��0.2* ��� $
��0.2* ��� $
��0.2* ��� $
��0.2* �.+��� -	   $ ConvertButton��$��변환하기��$��Center=�$��0q�$	��100��$��2���� -
   $ CancelButton��$��취 소��$��Center=�$��0q�$	��100��$��3��� $��40��$��10,160,10,0q�$	��Top=�$	��774�� �� $
��0.5* ��� $
��0.5* ��� $
��0.5* �.+��� $��0��$ 
Horizontal=�.+��� $��프레임레이트��$��Center=��� -   $ FrameRateField��$	��100��$ NoWrap=�$��30��$��Center=��� $��1��$ 
Horizontal=�.+��� $��비트 레이트��$��Center=��� -   $ BitRateField��$	��100��$��10000��$ NoWrap=�$��Center=�)  #MahApps.Metro.Controls.ToggleSwitch  -     Name$ IsShowConsole��    OnLabel$  Show Console��!   OffLabel$! Hide Console��$��2��$��Center=�"   	IsChecked$" FalseY�$��Center=�$
��Left=�$��Stretch=�$	��160��� -   $ Progress��$y�Hidden=�# K� ZIndex$# 1�����	#9C0078D7.+�)  #MahApps.Metro.Controls.ProgressRing  ���	#CCFFFFFF