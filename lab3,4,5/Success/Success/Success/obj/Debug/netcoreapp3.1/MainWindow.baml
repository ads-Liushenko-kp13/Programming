   M S B A M L   `   `   `  ����B  >Success, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SuccessSuccess  5   	       Success.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Success     5   	     � Title$  
MainWindow��5   	   $	��531��6   $	��903��6)   .��5	      � .+�5
   
   c� $��Center=�6   $��26��6/   $��0,10,0,0q�6;   $	��Top=�6M   $	��780��6e   .@�5      �� -   5         ��Name$ AuctionButton��5      $��Auction��6,   $
��Left=�6>   $	��Top=�6Y   4  .System.Windows.Automation.AutomationProperties   Name$ AuctionButton��6r   6�   �� 5      -   5        $ 	LotButton��5      $	��Lot��6(   $	��Top=�66   $ 	LotButton��6N   6t   �� 5      -   5        $ ParticipantButton��5      $��Participant��60   $	��Top=�6F   $
��Left=�6^   $ ParticipantButton��6y   6�   5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ StartDatePicker��5      $
��Left=�6.   $��	10,71,0,0q�6I   $	��Top=�6\   6t     5   
   -   5        $ EndDatePicker��5      $
��Left=�6,   $��
139,71,0,0q�6G   $	��Top=�6[   6t   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	BuyerGrid��5      $��387,126,10,247q�6&      
IsReadOnly$ False��6>     5   
   -   5        $ AuctionGrid��5      $��0,134,560,0q�6(   $
 True��6=   6O     5   
   -   5        $ LotGrid��5      $��377,357,10,10q�6$   $
 True��6;   �� 5   
   $��Buyer��6   $
��Left=�6    $��
400,18,0,0q�6;   $	��Top=�6O   $
��Bold"�6g   $��Italic$�6y   �� 5   
   $	��Lot��6   $
��Left=�6   $	��Top=�69    J� RenderTransformOrigin$ 
0.39,0.612&�6Q   $
��Bold"�6t   $��Italic$�6�   $��400,273,0,0q�6�   �� 5   
   -	   5         ��Name$ TopPriceLabel��5      $��TopPrice��6'   $
��Left=�6:   $��394,299,0,0q�6U   $	��Top=�6j   $ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0Q�6&   T� 5      5      5      �� 5    
   -
   5        $ TopDifferenceLabel��5       $��TopDifference��6,   $
��Left=�6D   $��394,325,0,0q�6_   $	��Top=�6t   �� 5!   
   -   5        $ TopBuyerLabel��5!      $��TopBuyer��6'   $
��Left=�6:   $��
419,57,0,0q�6U   $	��Top=�6i   �� 5"   
   -   5        	 ��Name$	 IsNotSoldCheckBox��5"      $��Not Sold��6.   $
��Left=�6A   $��811,323,0,0q�6\   $	��Top=�6q   6�   5$      5%      