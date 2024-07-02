interface Movie {
    id: number;
    title: string;
    year: number;
    category: string;
    image: string;
  }

const MOVIES: Movie[] = [
    {
      id: 1,
      title: 'Убить Билла',
      year: 2003,
      category: 'movies',
      image: 'https://avatars.mds.yandex.net/i?id=10d559b94d10f768afe8cdcb9fbaca8e9291c299-10113980-images-thumbs&n=13'
    },
    {
      id: 2,
      title: 'Оппенгеймер',
      year: 2023,
      category: 'movies',
      image: 'https://arynews.tv/wp-content/uploads/2023/07/Oppenheimer-3-696x342.jpg',
    },
    {
      id: 3,
      title: 'Гарри Поттер и Филосовский камень',
      year: 2001,
      category: 'movies',
      image: 'https://pic.rutube.ru/video/af/c7/afc7ab6b0601db171f61e83e1385cd35.jpg',
    },
    {
      id: 4,
      title: 'Чарли и шоколадная фабрика',
      year: 2005,
      category: 'movies',
      image: 'https://avatars.mds.yandex.net/i?id=d8ed5ba1ec51fa736a5c61eca862a7502ee22ba8-4233236-images-thumbs&n=13',
    },
    {
      id: 5,
      title: 'Зомби по имени Шон',
      year: 2004,
      category: 'movies',
      image: 'https://avatars.mds.yandex.net/i?id=07bd79f912ae71b070629538e65ee85f2383b1d4-3569718-images-thumbs&n=13',
    },
    {
      id: 6,
      title: 'Проклятие Аннабель (2014)',
      year: 2014,
      category: 'movies',
      image: 'https://www.dictio.id/uploads/db3342/original/3X/e/1/e1718d20b6b132a7ada6dae05fe0059b8b7b38d8.jpg',
    },
    {
      id: 7,
      title: 'Аватар: Легенда об Аанге',
      year: 2024,
      category: 'series',
      image: 'https://avatars.mds.yandex.net/i?id=253ea2c374890e1d57f8e363ee8b32e574abc51a-8899644-images-thumbs&n=13',
    },
    {
      id: 8,
      title: 'Уэйн',
      year: 2019,
      category: 'series',
      image: 'https://avatars.mds.yandex.net/i?id=a4eac92aa1a0c4b533822d43acab52f2448ca924-12613135-images-thumbs&n=13',
    },
    {
      id: 9,
      title: 'Ходячие мертвецы',
      year: 2010,
      category: 'series',
      image: 'https://disgustingmen.com/wp-content/uploads/2019/02/Walking-Dead-9-season.jpg',
    },
    {
      id: 10,
      title: 'Уэнсдэй',
      year: 2022,
      category: 'series',
      image: 'https://avatars.mds.yandex.net/i?id=64c6ff1bcd097d0297438b9542987d379cf7f029-12319715-images-thumbs&n=13',
    },
    {
      id: 11,
      title: 'Очень странные дела',
      year: 2016,
      category: 'series',
      image: 'https://pm1.aminoapps.com/6999/21a8f6450884d5cab715d7332a946c8eba33a429r1-640-480v2_uhq.jpg',
    },
    {
      id: 12,
      title: 'Волчонок',
      year: 2011,
      category: 'series',
      image: 'https://avatars.mds.yandex.net/i?id=82cf29210d427766d189e222a970bece11c7a74b-12423030-images-thumbs&n=13',
    },
    {
      id: 13,
      title: 'Рапунцель',
      year: 2010,
      category: 'cartoons',
      image: 'https://avatars.dzeninfra.ru/get-zen_doc/271828/pub_652d7706c094161c02071aca_652d7afc8365541c3980e5f5/scale_1200',
    },
    {
      id: 14,
      title: 'Как приручить дракона',
      year: 2010,
      category: 'cartoons',
      image: 'https://avatars.mds.yandex.net/i?id=c475fee105a718b41ae4f257999eae175fd421ea-12422060-images-thumbs&n=13',
    },
    {
      id: 15,
      title: 'Тэркель в беде',
      year: 2004,
      category: 'cartoons',
      image: 'https://avatars.mds.yandex.net/i?id=169f177c84af26bfa0a4001ce0730286652fbeac-8438802-images-thumbs&n=13',
    },
    {
      id: 16,
      title: 'Принцесса и лягушка',
      year: 2009,
      category: 'cartoons',
      image: 'https://avatars.mds.yandex.net/i?id=4028809d424ae7887898ad6c2f5777cb8bf674cf-4535954-images-thumbs&n=13',
    },
    {
      id: 17,
      title: 'Истребитель демонов: Поезд «Бесконечный»',
      year: 2020,
      category: 'cartoons',
      image: 'https://avatars.mds.yandex.net/i?id=3e97ec2529bd0f6083a161efcf645212120ff284-12675760-images-thumbs&n=13',
    },
    {
      id: 18,
      title: 'Головоломка',
      year: 1015,
      category: 'cartoons',
      image: 'https://avatars.mds.yandex.net/i?id=b6112156d7e1efe7700e116bf71c7073fbf9697c-11370034-images-thumbs&n=13',
    }
]

export default MOVIES