   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5   	        WpfApplication1.EditRecipe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:WpfApplication1     5   	   U QMahApps.Metro, Version=0.13.1.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   btoolkitTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5   	   -   5          � Title$  	Uppskrift��5   	   $��746.597��6   $��892.657��6,    � WindowStartupLocation$ CenterScreen=�6S      SecondaryWindowStyle#��[  5	   	    � 	Resources 5      (   "WpfApplication1.FoodProjectDataSet  foodProjectDataSet  mainRecipeDetailsViewSource �� Source �� Source  measureViewSource  ingredientViewSource  recipeViewSource  cuisineInfoViewSource  cuisineViewSource��%�  &	       &	      7  &	 J     7  &	 w     7  &	 �     7  &	 �     7  &	     7    5   
   6#   �� 5   
    6C   �� *MainRecipeDetails+8   �� 5   
    69   �� *	Measure+8   �� 5   
    6<   �� *
Ingredient+8   �� 5   
    68   �� *Recipe+8   �� 5   
    6=   �� *CuisineInfo+8   �� 5   
    69   �� *	Cuisine+8   5      .��5      � .+�5   
   �� $��Nafn:��6   $
��Left=�6    $��	36,27,0,0q�6;   $��27��6N   $	��Top=�6Z   �� 5   
   -   5         ��Name$ txtName��5   X    � DataContext# [ 6   $
��Left=�6i   $��23��6�   $��	79,31,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��193��6�   ��6B   �� *name+6�   �� 5   
   $��Einkunn:��6   $
��Left=�6#   $��	19,80,0,0q�6>   $	��Top=�6Q    J� RenderTransformOrigin$ 	0.2,0.615&�6i   �� 5   
   -   5        	 ��Name$	 	sliRating��5   �   # [ 6   $
��Left=�6�   $��	81,87,0,0q�6�   $	��Top=�6�   $	��193��6�   
 �� IsSnapToTickEnabled
 .  � Maximum$ 5Q�6!   � Minimum$ 0Q�6-   � Value 6A   �� *rating+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 69  �� 5    
   -   5         ��Name$ 	lblRating��5       $
��Left=�6T   $��
279,83,0,0q�6o   $	��Top=�6�   ��6#   �� *Value+ �� ElementName$ 	sliRating��6�   �� 5#   
   $��	Hráefni:��6   $
��Left=�6#   $��
23,156,0,0q�6>   $	��Top=�6R   -  'System.Windows.Controls.AutoCompleteBox  5&   
   -   5          Name$ txtIngredient��5&   "   # [ 6:      
FilterMode$ Contains=�5'   "      IsTextCompletionEnabled .    ValueMemberPath$
 name��5)   "   $��
74,160,0,0q�5*   "   $��23��66   $	��Top=�6B   $
��Left=�6Z   $	��136��6u      ItemsSource 5&   n   ��    ItemTemplate 5+      �� 5,      .R�5-      �� ��6    �� *name+5.      50      �� 54   
   $��Magn:��6   $
��Left=�6    $��213,156,0,0q�6;   $	��Top=�6P   �� 55   
   -   5        $ txtQuantity��55      $
��Left=�6'   $��23��6B   $��256,160,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��39��6�    J� IsHitTestVisible . 6�   �� 58   
   $��	Mælikv.:��6   $
��Left=�6#   $��295,156,0,0q�6>   $	��Top=�6S   $��56��6k   �� 59   
   -   5         ��Name$ 	cbMeasure��59   D   # [ 6    �� DisplayMemberPath$
 name��6W   $
��Left=�6p   $��22��6�   $��351,160,0,0q�6�   $��0��6�   $��52��6�   $	��Top=�6�   ��6�   �� 6�   �� 5<   
   -   5         ��Name$ btnAddIngredient��5<      $��
Bæta við��6+   $
��Left=�6>   $��338,187,0,0q�6Y   $	��Top=�6n   $��75��6�   6�   �� 5?   
   -	   5         ��Name$ imgCheck��5?      $
��Left=�6"   $��20��6=   $��418,189,0,0q�6I   $	��Top=�6^   $��20��6v   �� 5@   
   -
   5        $ lblCheck��5@      $�� ��6"   $
��Left=�6-   $��187,209,0,0q�6H   $	��Top=�6]   $	��226��6u   $��9(�6�   $��Right=�6�   &   System.Windows.Controls.DataGrid  5D   
   -   5          Name$ mainRecipeDetailsDataGrid��5D         
IsReadOnly . {�.     AutoGenerateColumns  .  !   EnableRowVirtualization! . $��
29,240,0,0q�6�   "   RowDetailsVisibilityMode$" VisibleWhenSelected=�6�   $
��Left=�6$  $	��400��6?  $	��372��6K  $	��Top=�6X  ��6�   �� # [ # � ContextMenu# 5E      �� 5F      .@�5G      m� -   5        $ m�Name$$ DataGridRightClick��5G      $��Eyða��6;   6I   5H      %   Columns% 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      -   5        ingredientsColumn��,  &System.Windows.Controls.DataGridColumn&   Header$& Hráefni��5K   `   '   Width5  /System.Windows.Controls.DataGridLengthConverter$' 2* 6q   1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 6@   �� *Ingredients+6q     5L      -   5        quantityColumn��$
& Magn��5L   Z   $' * 6h   ( 6=   �� *
Quantity+6h     5M      -   5        unitsColumn��$& Mælieining��5M   T   $' * 6h   ( 6:   �� *Units+6h   5O      �� 5P   
   $��Nýtt hráefni?��6   $
��Left=�6(   $��264,623,0,0q�6C   $	��Top=�6X   �� 5Q   
   -   5        $ btnNewIngredient��5Q      $��Nýskrá��6+   $
��Left=�6<   $��347,625,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5R   
   $��	Aðferð:��6   $
��Left=�6"   $��444,240,0,0q�6=   $	��Top=�6R   �� 5U   
   $��Tögg:��6   $
��Left=�6    $��
411,27,0,0q�6;   $	��Top=�6O   �� 5V   
   -   5        $ 	cbCuisine��5V   D   # [ 6   $
 name��6W   $
��Left=�6p   $
��Auto��6�   $��
451,31,0,0q�6�   $��0��6�   $	��Top=�6�   $	��101��6�   ��6�   �� ��5W      �� 5X      .R�5Y      $� 5Z      5\      �� 5]   
   -   5        $ 	btnAddTag��5]      $��Bæta��6$   $
��Left=�63   $	��Top=�6N   $��46��6f   $��
557,31,0,0q�6q   6�   �� 5`   
   -   5        $ 	imgCheck2��5`      $
��Left=�6#   $��20��6>   $��
606,32,0,0q�6J   $	��Top=�6^   $��20��6v   �� 5a   
   -   5        $ 	lblCheck2��5a      $�� ��6#   $
��Left=�6.   $��
451,57,0,0q�6I   $	��Top=�6]   $	��152��6u   $��9(�6�   $��Right=�6�   $��23��6�   �� 5d   
   -   5        ) ��Name$) 	lbCuisine��5d        AltCuisineListBoxStyle#��[ 6%   $��
444,80,0,0q�6�   $
��Left=�6�   $	��175��6�   $	��125��6�   $	��Top=�6�   ��6U   �� # [ ��5e      �� 5f      .R�5g      �� $ cuisineLabel��6   $��1��6N   $
��Left=�6^   $��3q�6y   $��0��6�   $��Center=�6�   ��62   �� *	Cuisine+6�   5h      # 5j      �� 5k      .@�5l      m� -   5        $��Eyða��5l      6-   5m      5o      �� 5p   
   $��Nýtt tagg?��6   $��501,209,0,0q�6%   $��10(�6:   $��29��6H   $	��Top=�6T   $
��Left=�6l   $��57��6�   �� 5q   
   -   5        $ btnNewCuisine��5q      $��Nýskrá��6(   $
��Left=�69   $��558,209,0,0q�6T   $	��Top=�6i   $��61��6�   6�   �� 5t   
   -   5        $ image_urlImage��5t   @   # [ 6   $
��Left=�6X   $��
647,50,0,0q�6s   $��0��6�   $	��Top=�6�   $	��160��6�   $	��210��6�   $
��Fill=�6�   ��6�   �� *	image_url+6�   �� 5u   
   -   5        $ btnBrowseImage��5u      $��Browse��6)   $
��Left=�6:   $��785,220,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5v   
   $��Mynd:��6   $
��Left=�6    $��
625,27,0,0q�6;   $	��Top=�6O   �� 5y   
   -   5        $ descriptionTextBox��5y   B   # [ 6   $
��Left=�6^   $	��340��6y   $��444,271,0,0q�6�   $��0��6�   $	��Top=�6  $	��407��6$  * �� AcceptsReturn* . + �� 
AcceptsTab+ . $
 Wrap=�6W  ��6�   �� *description+$ TwoWay=� .  . 6k  �� 5}   
   -   5        $ btnUpdateRecipe��5}      $��Skrá Uppskrift��6*   $
��Left=�6C   $��735,671,0,0q�6^   $	��Top=�6s   $��99��6�   $��26��6�   6�   �� 5   
   -   5        $��Eyða Uppskrift��5      $
��Left=�6*   $��
19,671,0,0q�6E   $	��Top=�6Y   $��99��6q   $��26��6|   6�   5�      5�      