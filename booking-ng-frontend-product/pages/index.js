import Head from 'next/head'
import styles from '../styles/Home.module.css'

export default function Home(props) {
  return (
    <div className={styles.container}>
      <Head>
        <title>BookingNG Product</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main className={styles.main}>
        <h1 className={styles.title}>
          Welcome to <a href="">BookingNG</a>
        </h1>

        <p className={styles.description}>
          Available routes:
        </p>

        <div className={styles.grid}>
          {props.data.map(route => (
            <a href="" className={styles.card}>
              <h3>{route.sourceAirport} - {route.destinationAirport}</h3>
              <p>{route.airline} - {route.codeShare} - {route.stops} stops</p>
            </a>
          ))}
        </div>
      </main>

      <footer className={styles.footer}>
        <a
          href=""
          rel="noopener noreferrer"
        >
          Powered by electricity
        </a>
      </footer>
    </div>
  )
}

export async function getStaticProps(context) {
  const res = await fetch(`http://booking-ng-frontend-product-bff/routes`)
  const data = await res.json()

  if (!data) {
    return {
      notFound: true,
    }
  }

  return {
    props: { data },
  }
}
