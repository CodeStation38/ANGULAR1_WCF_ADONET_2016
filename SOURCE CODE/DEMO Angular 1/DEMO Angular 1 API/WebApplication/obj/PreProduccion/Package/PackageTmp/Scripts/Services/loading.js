'use strict';


app.factory('loading', ["$rootScope", "$timeout", function ($rootScope,$timeout) {

  var  entrada = true;

        function getTypeDocument(TypeDoc)
        {
            switch(TypeDoc) {
                case 'CC':
                    return 1;
                    break;
                case 'NI':
                    return 2;
                    break;
                case 'CE':
                    return 3;
                    break;
                case 'TI':
                    return 4;
                    break;
                case 'PS':
                    return 5;
                    break;
                case 'CD':
                    return 6;
                    break;
                case 'RC':
                    return 7;
                    break;
                default:
                    return 1;
            }
        }

   return {
      loading: function () {
        $rootScope.CargarGif = true;
      },
      ready:function(){
        $rootScope.CargarGif = false;
      },
       cerrarLoding : function(){


           if ($rootScope.CargarGif) {
               $rootScope.CargarGif = false;
           }
       },
     loadingAlert:function(msg ,typeAlert){
       $rootScope.msgAlert = msg;
       $rootScope.typeAlert = typeAlert;
       $rootScope.cargarAlert = true;
       if(entrada){
         entrada = false;
       $timeout(function() {
             $rootScope.msgAlert = '';
             $rootScope.typeAlert = '';
             $rootScope.cargarAlert = false;
             entrada = true;
       }, 5000);

       }


      },
     readyAlert:function(){

       $rootScope.msgAlert = '';
       $rootScope.typeAlert = '';
       $rootScope.cargarAlert = false;

     },

       returnTipeDocument: function(TypeDoc){

           switch(TypeDoc) {
               case 'CC':
                   return 1;
                   break;
               case 'NI':
                    return 2;
                    break;
               case 'CE':
                   return 3;
                   break;
               case 'TI':
                   return 4;
                   break;
               case 'PS':
                   return 5;
                   break;
               case 'CD':
                   return 6;
                   break;
               case 'RC':
                   return 7;
                   break;
               default:
               return 1;
           }

       }



    };
  }]);
