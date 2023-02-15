String.prototype.repeatify = function(count){
    return count > 0 ? this.repeat(count) : '';
}