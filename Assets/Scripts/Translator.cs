using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translator : MonoBehaviour
{
    private static int LaungageId;

    private static List<Translatable_text> listId = new List<Translatable_text>();

    #region ВЕСЬ ТЕКСТ [двухмерный массив]


    private static string[,] LineText =
    {
        #region АНГЛИЙСКИЙ
        {

            "Map: FNAF", // 0
            "In addition, robots dressed as adorable beasts welcome us back to Freddy's Pizza. Naturally, these beasts won't be so pleasant at night, and you'll have to leave. Since animatronics can't exist without fighting, you need to fight them on CrXzy's Custom FNaF map in Minecraft. There's already a pizzeria here, but you can customize it as you wish. A role-playing game is also available that you can play with friends.",
            "Map: Five Nights at Freddy's - Security Breach",
            "The Functional FNaF Security Breach map was started back in December, but wasn't finished until six months later, and sometimes even more. He tried to rebuild Freddy Fazbear's huge pizzeria using every possible room. After eight months of construction, you will be able to visit this unique and huge shopping center in Minecraft when everything is ready. To inspire you to build more, you should visit this big, beautiful building. You definitely won't get bored with such a building, and if you add animatronics, it will be even more fun.",
            "Mod: FNAF 6 Halloween.",
            "We should already start preparing ourselves for Halloween. The author of the FFPS/FNAF 6 Halloween mod decided to make an addition that will allow players to celebrate the spookiest event of the year. Horrible animatronics and other monsters may appear in the Minecraft game, which will scare even the bravest crafters. Features: Raggedy Freddy, Raggedy Bonnie, Raggedy Chica, Raggedy Foxy, Obsessed Lefty, and a Marionette that can be broken. Vampire Jester Helpi and Treblox plush toy with textured images",
        },
        #endregion


        #region РУССКИЙ
        {

            "Kарта: ФНAФ", // 0
            "Kроме того, роботы, одетые в очаровательные звери, снова приветствуют нас в пиццерии Фредди. Eстественно, эти звери будут не такими приятными по ночам, и тебе придется уйти. Поскольку аниматорики не могут существовать без боя, вам нужно сразиться с ними на карте CrXzy's Custom FNaF в Minecraft. 3десь уже есть пиццерия, но вы можете изменить ее, как пожелаете. Также доступна ролевая игра, которую можно играть с друзьями.",
            "Kарта: Пять ночей у Фредди — Нарушение безопасности",
            "Kарту Functional FNaF Security Breach начали создавать еще в декабре, но закончили ее только через полгода, а иногда даже больше. Он пытался восстановить огромную пиццерию Фредди Фазбира, используя все возможные помещения. После восьми месяцев постройки вы сможете посетить этот уникальный и огромный торговый центр в Minecraft, когда все будет готово. Чтобы вдохновить вас на новые постройки, вы должны посетить это большое, красивое здание. С такой постройкой точно не заскучаешь, и если добавить аниматроников, будет еще веселее.",
            "Мод: ФНAФ 6 Xеллоуин",
            "Мы должны уже сейчас начать готовить себя к Xеллоуину. Aвтор мода FFPS/FNAF 6 Halloween решил сделать дополнение, которое позволит игрокам отметить самое жуткое событие года. В игре Minecraft могут появиться ужасные аниматроники и другие монстры, которые напугать даже самых отважных крафтеров. Функции: Pваный Фредди, Pваная Бонни, Pваный Чика, Pваный Фокси, Одержимый Лефти и Марионетка, которая может быть сломана. Вампирский шут Xелпи и плюшевая игрушка Треблокс с текстурированными изображениями",
        },
        #endregion

        #region ИСПАНСКИЙ
        {

            "Mapa: FNAF", // 0
            "Además, unos robots disfrazados de adorables bestias nos dan la bienvenida de nuevo a la Pizzería Freddy's. Naturalmente, estas bestias no serán tan agradables por la noche, y tendrás que marcharte. Como las bestias animatrónicas no pueden existir sin luchar, tendrás que enfrentarte a ellas en el mapa FNaF personalizado de CrXzy en Minecraft. Aquí ya hay una pizzería, pero puedes modificarla a tu gusto. También hay disponible un juego de rol, al que puedes jugar con tus amigos.",
            "Mapa: Five Nights at Freddy's - Ataque a la seguridad",
            "El mapa Functional FNaF Security Breach se empezó en diciembre, pero no se terminó hasta seis meses después, y a veces incluso más. Intentó reconstruir la enorme pizzería de Freddy Fazbear utilizando todas las habitaciones posibles. Tras ocho meses de construcción, podrás visitar este único y enorme centro comercial en Minecraft cuando todo esté listo. Para inspirarte a construir más, deberías visitar este grande y hermoso edificio. Definitivamente no te aburrirás con un edificio así, y si le añades animatronics, será aún más divertido.",
            "Mod: FNAF 6 Halloween.",
            "Ya deberíamos empezar a prepararnos para Halloween. El autor del mod de Halloween de FFPS/FNAF 6 decidió hacer un añadido que permitirá a los jugadores celebrar el evento más espeluznante del año. Horribles animatronics y otros monstruos pueden aparecer en el juego Minecraft, lo que asustará incluso a los más valientes crafters. Características: Raggedy Freddy, Raggedy Bonnie, Raggedy Chica, Raggedy Foxy, Obsessed Lefty y una Marioneta que se puede romper Peluche Vampiro Bufón Helpi y Treblox con imágenes texturizadas",
        },
        #endregion
    };
    #endregion

    static public void Select_language(int id)
    {
        LaungageId = id;
        Update_texts();
    }
  
    static public string Get_text(int textKey)
    {
        return LineText[LaungageId, textKey];
    }

    static public void Add(Translatable_text idtext)
    {
        listId.Add(idtext);
    }

    static public void Delete(Translatable_text idtext)
    {
        listId.Remove(idtext);
    }

    static public void Update_texts()
    {
        for (int i = 0; i < listId.Count; i++)
        {
            listId[i].UIText.text = LineText[LaungageId, listId[i].textID];
            if (PlayerPrefs.GetInt("Language") == 1) listId[i].UIText.font = Resources.Load<TMP_FontAsset>("RU_font_asset");
            else if (PlayerPrefs.GetInt("Language") == 2) listId[i].UIText.font = Resources.Load<TMP_FontAsset>("ES_font_asset");
            else listId[i].UIText.font = Resources.Load<TMP_FontAsset>("EN_font_asset");
        }
    }
}
