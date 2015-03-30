﻿namespace ConsoleApplication1
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class Alphabet
    {
        private static Dictionary<char, char[,]> alphabet = new Dictionary<char, char[,]>();

        public static char[,] GetLetter( char let)
        {
            return alphabet[let];
        }
        
        public static void InitialiseAlphabet()
        {
            alphabet.Add(' ', new char[,]{
                                         {'|',' ',' ',' ',' ',' ',' ',' ','|'},
                                         {'|',' ',' ',' ',' ',' ',' ',' ','|'},
                                         {'|',' ',' ',' ',' ',' ',' ',' ','|'},
                                         {'|',' ',' ',' ',' ',' ',' ',' ','|'},
                                         {'|','_','_','_','_','_','_','_','|'}
                                        });
            alphabet.Add('A', new char[,]{
                                         {' ',' ',' ',' ','_',' ', ' ',  ' ',' '},
                                         {' ',' ',' ','/',' ','\\',' ',  ' ',' '},
                                         {' ',' ','/',' ','_',' ', '\\', ' ',' '},
                                         {' ','/',' ','_','_','_', ' ', '\\',' '},
                                         {'/','_','/',' ',' ',' ', '\\', '_','\\'}
                                        });
            alphabet.Add('B', new char[,]{
                                         {' ','_','_','_','_',' ',' ', ' '},
                                         {'|',' ','_','_',' ',')',' ', ' '},
                                         {'|',' ',' ','_',' ','\\',' ', ' '},
                                         {'|',' ','|','_',')',' ','|',' '},
                                         {'|','_','_','_','_','/',' ',' '}
                                        });
            alphabet.Add('C', new char[,]{
                                         {' ',' ',' ','_','_','_','_',' ',' '},
                                         {' ',' ','/',' ','_','_','_','|',' '},
                                         {' ','|',' ','|',' ',' ',' ',' ',' '},
                                         {' ','|',' ','|','_','_','_',' ',' '},
                                         {' ',' ','\\','_','_','_','_','|',' '}
                                        });
            alphabet.Add('D', new char[,]{
                                         {' ',' ','_','_','_','_',' ',' ',' '},
                                         {' ','|',' ',' ','_',' ','\\',' ',' '},
                                         {' ','|',' ','|',' ','|',' ','|',' '},
                                         {' ','|',' ','|','_','|',' ','|',' '},
                                         {' ','|','_','_','_','_','/',' ',' '}
                                        });
            alphabet.Add('E', new char[,]{
                                         {' ',' ','_','_','_','_','_',' ',' '},
                                         {' ','|',' ','_','_','_','_','|',' '},
                                         {' ','|',' ',' ','_','|',' ',' ',' '},
                                         {' ','|',' ','|','_','_','_',' ',' '},
                                         {' ','|','_','_','_','_','_','|',' '}
                                        });
            alphabet.Add('F', new char[,]{
                                         {' ',' ','_','_','_','_','_','_',' '},
                                         {' ','|',' ',' ','_','_','_','_','|'},
                                         {' ','|',' ','|','_',' ',' ',' ',' '},
                                         {' ','|',' ',' ','_','|',' ',' ',' '},
                                         {' ','|','_','|',' ',' ',' ',' ',' '}
                                        });
            alphabet.Add('G', new char[,]{
                                         {' ',' ',' ','_','_','_','_',' ',' '},
                                         {' ',' ','/',' ','_','_','_','|',' '},
                                         {' ','|',' ','|',' ',' ','_',' ',' '},
                                         {' ','|',' ','|','_','|',' ','|',' '},
                                         {' ',' ','\\','_','_','_','_','|',' '}
                                        });
            alphabet.Add('H', new char[,]{
                                         {' ',' ','_',' ',' ',' ','_',' ',' '},
                                         {' ','|',' ','|',' ','|',' ','|',' '},
                                         {' ','|',' ','|','_','|',' ','|',' '},
                                         {' ','|',' ',' ','_',' ',' ','|',' '},
                                         {' ','|','_','|',' ','|','_','|',' '}
                                        });
            alphabet.Add('I', new char[,]{
                                         {' ',' ',' ','_','_','_',' ',' ',' '},
                                         {' ',' ','|','_',' ','_','|',' ',' '},
                                         {' ',' ',' ','|',' ','|',' ',' ',' '},
                                         {' ',' ',' ','|',' ','|',' ',' ',' '},
                                         {' ',' ','|','_','_','_','|',' ',' '}
                                        });
            alphabet.Add('J', new char[,]{
                                         {' ',' ',' ',' ',' ',' ','_',' ',' '},
                                         {' ',' ',' ',' ',' ','|',' ','|',' '},
                                         {' ',' ','_',' ',' ','|',' ','|',' '},
                                         {' ','|',' ','|','_','|',' ','|',' '},
                                         {' ',' ','\\','_','_','_','/',' ',' '}
                                        });
            alphabet.Add('K', new char[,]{
                                         {' ',' ','_',' ',' ','_','_',' ',' '},
                                         {' ','|',' ','|','/',' ','/',' ',' '},
                                         {' ','|',' ','\'',' ','/',' ',' ',' '},
                                         {' ','|',' ','.',' ','\\',' ',' ',' '},
                                         {' ','|','_','|','\\','_','\\',' ',' '}
                                        });
            alphabet.Add('Z', new char[,]{
                             {' ',' ','_','_','_','_','_',' ',' '},
                             {' ','|','_','_',' ',' ','/',' ',' '},
                             {' ',' ',' ','/',' ','/',' ',' ',' '},
                             {' ',' ','/',' ','/','_',' ',' ',' '},
                             {' ','/','_','_','_','_','|',' ',' '}
                            });
            alphabet.Add('Y', new char[,]{
                             {' ','_','_' ,' ' ,' ',' ','_','_',' '},
                             {' ','\\',' ','\\',' ','/',' ','/',' '},
                             {' ',' ','\\',' ' ,'V',' ','/',' ',' '},
                             {' ',' ',' ' ,'|' ,' ','|',' ',' ',' '},
                             {' ',' ',' ' ,'|' ,'_','|',' ',' ',' '}
                            });
            alphabet.Add('X', new char[,]{
                             {' ','_' ,'_' ,' ' ,' ' ,'_' ,'_' ,' ',' '},
                             {' ','\\',' ','\\' ,'/' ,' ' ,'/' ,' ',' '},
                             {' ',' ' ,'\\',' ' ,' ' ,'/' ,' ' ,' ',' '},
                             {' ',' ' ,'/' ,' ' ,' ' ,'\\',' ' ,' ',' '},
                             {' ','/' ,'_' ,'/' ,'\\','_' ,'\\',' ',' '}
                            });
            alphabet.Add('W', new char[,]{
                             {'_' ,'_' ,' ' ,' '  ,' ' ,' ' ,' '  ,' ',' ',' ','_','_'},
                             {'\\',' ' ,'\\',' '  ,' ' ,' ' ,' '  ,' ',' ','/',' ','/'},
                             {' ' ,'\\',' ' ,'\\' ,' ' ,'/' ,'\\' ,' ','/',' ','/',' '},
                             {' ' ,' ' ,'\\',' '  ,'V' ,' ' ,' '  ,'V',' ','/',' ',' '},
                             {' ' ,' ' ,' ' ,'\\' ,'_' ,'/' ,'\\' ,'_','/',' ',' ',' '}
                            });
            alphabet.Add('V', new char[,]{
                             {'_' ,'_' ,' ' ,' ' ,' ' ,' ' ,' ' ,'_','_'},
                             {'\\',' ' ,'\\',' ' ,' ' ,' ' ,'/' ,' ','/'},
                             {' ' ,'\\',' ' ,'\\',' ' ,'/' ,' ' ,'/',' '},
                             {' ' ,' ' ,'\\',' ' ,'V' ,' ' ,'/' ,' ',' '},
                             {' ' ,' ' ,' ' ,'\\','_' ,'/' ,' ' ,' ',' '}
                            });
            alphabet.Add('U', new char[,]{
                             {' ' ,' ' ,'_' ,' ' ,' ' ,' ' ,'_' ,' ',' '},
                             {' ' ,'|' ,' ' ,'|' ,' ' ,'|' ,' ' ,'|',' '},
                             {' ' ,'|' ,' ' ,'|' ,' ' ,'|' ,' ' ,'|',' '},
                             {' ' ,'|' ,' ' ,'|' ,'_' ,'|' ,' ' ,'|',' '},
                             {' ' ,' ' ,'\\','_' ,'_' ,'_' ,'/' ,' ',' '}
                            });
            alphabet.Add('T', new char[,]{
                             {' ' ,' ' ,'_' ,'_' ,'_' ,'_' ,'_' ,' ',' '},
                             {' ' ,'|' ,'_' ,' ' ,' ' ,' ' ,'_' ,'|',' '},
                             {' ' ,' ' ,' ' ,'|' ,' ' ,'|' ,' ' ,' ',' '},
                             {' ' ,' ' ,' ' ,'|' ,' ' ,'|' ,' ' ,' ',' '},
                             {' ' ,' ' ,' ' ,'|' ,'_' ,'|' ,' ' ,' ',' '}
                            });
            alphabet.Add('S', new char[,]{
                             {' ' ,' ' ,'_' ,'_' ,'_' ,'_' ,' ' ,' ',' '},
                             {' ' ,'/' ,' ' ,'_' ,'_' ,'_' ,'|' ,' ',' '},
                             {' ' ,'\\','_' ,'_' ,'_' ,' ' ,'\\',' ',' '},
                             {' ' ,' ' ,'_' ,'_' ,'_' ,')' ,' ' ,'|',' '},
                             {' ' ,'|' ,'_' ,'_' ,'_' ,'_' ,'/' ,' ',' '}
                            });
            alphabet.Add('R', new char[,]{
                             {' ' ,' ' ,'_' ,'_' ,'_' ,'_' ,' ' ,' ' ,' '},
                             {' ' ,'|' ,' ' ,' ' ,'_' ,' ' ,'\\',' ' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,'_' ,')' ,' ' ,'|' ,' '},
                             {' ' ,'|' ,' ' ,' ' ,'_' ,' ' ,'<' ,' ' ,' '},
                             {' ' ,'|' ,'_' ,'|' ,' ' ,'\\','_' ,'\\',' '}
                            });
            alphabet.Add('Q', new char[,]{
                             {' ' ,' ' ,' ' ,'_' ,'_' ,'_' ,' ' ,' ' ,' '},
                             {' ' ,' ' ,'/' ,' ' ,'_' ,' ' ,'\\',' ' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,' ' ,'|' ,' ' ,'|' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,'_' ,'|' ,' ' ,'|' ,' '},
                             {' ' ,' ' ,'\\','_' ,'_' ,'\\','_' ,'\\',' '}
                            });
            alphabet.Add('P', new char[,]{
                             {' ' ,' ' ,'_' ,'_' ,'_' ,'_' ,' ' ,' ' ,' '},
                             {' ' ,'|' ,' ' ,' ' ,'_' ,' ' ,'\\',' ' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,'_' ,')' ,' ' ,'|' ,' '},
                             {' ' ,'|' ,' ' ,' ' ,'_' ,'_' ,'/' ,' ' ,' '},
                             {' ' ,'|' ,'_' ,'|' ,' ' ,' ' ,' ' ,' ' ,' '}
                            });
            alphabet.Add('O', new char[,]{
                             {' ' ,' ' ,' ' ,'_' ,'_' ,'_' ,' ' ,' ' ,' '},
                             {' ' ,' ' ,'/' ,' ' ,'_' ,' ' ,'\\',' ' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,' ' ,'|' ,' ' ,'|' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,'_' ,'|' ,' ' ,'|' ,' '},
                             {' ' ,' ' ,'\\','_' ,'_' ,'_' ,'/' ,' ' ,' '}
                            });
            alphabet.Add('N', new char[,]{
                             {' ' ,' ' ,'_' ,' ' ,' ' ,' ' ,'_' ,' ' ,' '},
                             {' ' ,'|' ,' ' ,'\\',' ' ,'|' ,' ' ,'|' ,' '},
                             {' ' ,'|' ,' ' ,' ' ,'\\','|' ,' ' ,'|' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,'\\',' ' ,' ' ,'|' ,' '},
                             {' ' ,'|' ,'_' ,'|' ,' ' ,'\\','_' ,'|' ,' '}
                            });
            alphabet.Add('M', new char[,]{
                             {' ' ,'_' ,'_' ,' ' ,' ' ,'_' ,'_' ,' ' ,' '},
                             {'|' ,' ' ,' ' ,'\\','/' ,' ' ,' ' ,'|' ,' '},
                             {'|' ,' ' ,'|' ,'\\','/' ,'|' ,' ' ,'|' ,' '},
                             {'|' ,' ' ,'|' ,' ' ,' ' ,'|' ,' ' ,'|' ,' '},
                             {'|' ,'_' ,'|' ,' ' ,' ' ,'|' ,'_' ,'|' ,' '}
                            });
            alphabet.Add('L', new char[,]{
                             {' ' ,' ' ,'_' ,' ' ,' ' ,' ' ,' ' ,' ' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,' ' ,' ' ,' ' ,' ' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,' ' ,' ' ,' ' ,' ' ,' '},
                             {' ' ,'|' ,' ' ,'|' ,'_' ,'_' ,'_' ,' ' ,' '},
                             {' ' ,'|' ,'_' ,'_' ,'_' ,'_' ,'_' ,'|' ,' '}
                            });

        }
    }
}