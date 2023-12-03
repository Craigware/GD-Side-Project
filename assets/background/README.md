## Background
A scalable node that makes background management easier.

#### Background Layers
> [!NOTE]
> __Images of lower index will be placed behind those of higher index.__

 - Contains an array of texture2Ds. The array gets looped through upon _Ready(),  
 creating sprite2Ds as a child of the node containing background.cs asa script.

#### Parallax Speed
 - Helps determine how fast different layers move.
