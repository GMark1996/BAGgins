   M S B A M L   `   `   `  ����  RecordAndPlaybackBasics-WPFA    ;Microsoft.Samples.Kinect.RecordAndPlaybackBasics.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$   Record and Playback Basics��5   	   $	��600��5   	   $	��700��6    � 	Resources 5         MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush �� 
TargetType �� Property �� Value��%�   &	        &	 #     &	 F     '�� i     �� 5	   
   $ 	#ff6e6e6e��62   �� 5
   
   $ 	#ff52318f��64   �� 5   
   $ 	#ff00BCF2��62   �� 5   
   " ��6   .�5      ��  �@J�SnapsToDevicePixels . 64   5      5      .��5      � $��	10 0 10 0q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Images\Logo.png��6   $
��Left=�66   $
��Fill=�6Q   $��32��6`   $��81��6l   $��0 10 0 5q�6w   �� 5   
   $��0��6   $��0 0 -1 0q�6!   $��Right=�63   $��Center=�6O   #��[  6j   $��Segoe UI)�6�   $��18(�6�   Record and Playback Basics6�   �� 5   
   $��0��6   $��Images\Status.png��6   $
��None=�68   $��Center=�6G   $��0 0 0 5q�6d   � 5   
   $��1��6   
���   �$��	30 0 30 0q�6/    � ColumnDefinitions 5      �� 5      �� 5        5"      �� 5#      �� 5$      �� 5%      $
��Auto �6    .+�5'      (� -   5         (�Name$ kinectIRViewbox��5'      $��0��6/   $��0��6<   $��Center=�6L   .��5(      �� $��UniformToFill=�67   ��6   �� *ImageSource+67   5)      (� 5*      -   5        $ kinectDepthViewbox��5*      $��0��62   $��1��6?   $��Center=�6O   .��5+      �� $��UniformToFill=�67   ��6   �� *ImageSource+67   5,      (� 5-      -   5        $ kinectBodyIndexViewbox��5-      $��1��66   $��0��6C   $��Center=�6S   .��5.      �� $��UniformToFill=�67   ��6   �� *ImageSource+67   5/      (� 50      -   5        $ kinectBodyViewbox��50      $��1��61   $��1��6>   $��Center=�6N   .��51      �� $��UniformToFill=�67   ��6   �� *ImageSource+67   52      �� 53      $��2��6   $��2��6&   	 �� Orientation$	 
Horizontal=�6:   
�������.+�54      �� -   5        
 ��Name$
 RecordButton��54      $��Record��6/   $��90��6@   $��10q�6f   $��5q�6r   �� 55      -   5        $
 
PlayButton��55      $
��Play��6-   $��90��6<   $��10q�6`   $��5q�6l   �� 56      -   5        $
 HeadCoordinates��56      $	��XYZ��62   $	��369��6@   $��10q�6L   $��5q�6X   57      �� 58      $��2��6   $��1��6%   $��Right=�6_   $��Center=�6{   #��[ 6�   $��Segoe UI)�6�   $��18(�6�   $��10q�6�   ��65   �� *RecordPlaybackStatusText+6�   59      �� 5;   
   -	   5        $��	statusBar��5;   ?   $��3��6   $��Stretch=�6!   $��Bottom=�6P   
�������#��[  6~   .@�5<      �� ��6   �� *KinectStatusText+5=      5>      5?      