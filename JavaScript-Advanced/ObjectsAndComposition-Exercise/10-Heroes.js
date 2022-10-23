function solve(){
    return {
        mage: function (name){
            return{
                name,
                health:100,
                mana:100,
                cast: function(spellName){
                    this.mana--;
                    console.log(`${this.name} cast ${spellName}`);
                }
            };
        },
        fighter: function (name){
            return{
                name,
                health:100,
                stamina:100,
                fight: function(){
                    this.stamina--;
                    console.log(`${this.name} slashes at the foe!`);
                }
            };
        }
    };
}