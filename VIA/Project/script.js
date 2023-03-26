var paginationHandler = function(){
    var $paginationContainer = $(".pagination-container"),
        $pagination = $paginationContainer.find('.pagination ul');

    $pagination.find("li a").on('click.pageChange',function(e){
        e.preventDefault();
        var parentLiPage = $(this).parent('li').data("page"),
            currentPage = parseInt( $(".pagination-container div[data-page]:visible").data('page') ),
            numPages = $paginationContainer.find("div[data-page]").length;
        
        if ( parseInt(parentLiPage) !== parseInt(currentPage) ) {
            $paginationContainer.find("div[data-page]:visible").hide();
			
			document.getElementsByClassName("page-item")[currentPage].classList.remove("active");
			document.getElementsByClassName("page-item")[currentPage].classList.remove("disabled");	
			
			var index;

            if ( parentLiPage === '+' ) {
				index = currentPage+1>numPages ? numPages : currentPage+1;
            } else if ( parentLiPage === '-' ) {
				index = currentPage-1<1 ? 1 : currentPage-1;
            } else {
				index = parseInt(parentLiPage);			
            }
			$paginationContainer.find("div[data-page="+ index +"]").show();
			document.getElementsByClassName("page-item")[index].classList.add("active");
			document.getElementsByClassName("page-item")[index].classList.add("disabled");
        }
    });
};
$( document ).ready( paginationHandler );
  
  